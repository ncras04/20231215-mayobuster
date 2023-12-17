using GameState;
using Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using static Unity.VisualScripting.Member;

namespace Music
{
    [DisallowMultipleComponent]
    public class BeatVisualizer : MonoBehaviour
    {
        [SerializeField]
        private MiusicPlayer m_player = null;
        [SerializeField]
        private VisualBeat m_beatPrefab = null;
        [SerializeField]
        private float m_delayUntilStart = 3.0f;
        [SerializeField]
        private float m_movementSpeed = 1.0f;
        [SerializeField]
        private Transform m_leftSpawnPoint = null;
        [SerializeField]
        private Transform m_rightSpawnPoint = null;
        [SerializeField]
        private GameManager m_gameManager = null;
        [SerializeField]
        private AudioSource m_source = null;

        private Dictionary<VisualBeat, float> m_leftBeatInstances = new Dictionary<VisualBeat, float>();
        private Dictionary<VisualBeat, float> m_rightBeatInstances = new Dictionary<VisualBeat, float>();
        private SoundData m_data = null;
        private ObjectPool<VisualBeat> m_beatPool;

        private int m_currentBarIndex = 0;
        private float m_distanceToCenter = 0;
        private Vector3 m_directionLeftCenter = Vector3.zero;
        private Vector3 m_center = Vector3.zero;
        private float m_timeToCenter = 0;

        private MusicBar m_currentBar;
        private int m_sampleRate = 0;
        private float m_samplesPerBeat = 0.0f;
        private float m_sampleDelta = 0.0f;
        private int m_samplesLastFrame = 0;
        private int m_barCount = 0;
        private int m_beatCount = 0;


        private void Awake()
        {
            m_beatPool = new ObjectPool<VisualBeat>(m_beatPrefab, 0);

            m_player.BeatDropped += BeatDropper;
            m_player.TrackStarted += TrackStarted;

            CalculateDistanceToCenter();

            var audioConfig = AudioSettings.GetConfiguration();
            m_sampleRate = audioConfig.sampleRate;
            m_source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            m_data = m_player.Track;

            AudioConfiguration audioConfig = AudioSettings.GetConfiguration();
            m_currentBar = new MusicBar(m_data.SheetData[m_currentBarIndex, 0], m_data.SheetData[m_currentBarIndex, 1], 
                m_data.SheetData[m_currentBarIndex, 2]);
            m_sampleRate = audioConfig.sampleRate;
            m_samplesPerBeat = (60f / m_currentBar.BPM) * m_sampleRate;

            m_source.clip = m_data.SongFile;
            m_currentBar = new MusicBar(m_data.SheetData[m_barCount, 0], m_data.SheetData[m_barCount, 1], m_data.SheetData[m_barCount, 2]);

            m_samplesPerBeat = (60f / m_currentBar.BPM) * m_sampleRate;
            StartCoroutine(Test());
        }

        private IEnumerator Test()
        {
            yield return new WaitForSeconds(m_delayUntilStart);
            m_source.Play();
            DelayStart();
        }

        private void Update()
        {
            UpdateCurrentVisualBeat();
            MoveBeats();
        }

        private void DelayStart()
        {
            StartCoroutine(DelayedStart(m_timeToCenter));
        }

        private IEnumerator DelayedStart(float _time)
        {
            yield return new WaitForSeconds(_time);
            m_gameManager.StartGame();
        }

        private void CalculateDistanceToCenter()
        {
            m_center = ((m_leftSpawnPoint.position - m_rightSpawnPoint.position) * 0.5f) + m_rightSpawnPoint.position;

            m_distanceToCenter = ((m_leftSpawnPoint.position - m_rightSpawnPoint.position) * 0.5f).magnitude;

            m_directionLeftCenter = m_rightSpawnPoint.position - m_leftSpawnPoint.position;
            m_directionLeftCenter = m_directionLeftCenter.normalized;

            m_timeToCenter = m_distanceToCenter / m_movementSpeed;
            Debug.Log($"m_timeToCenter: {m_timeToCenter}");
            Debug.Log($"m_center: {m_center}");
        }

        private void MoveBeats()
        {
            List<VisualBeat> toRemove = new List<VisualBeat>();
            foreach (VisualBeat beat in m_leftBeatInstances.Keys.ToArray())
            {
                m_leftBeatInstances[beat] = m_leftBeatInstances[beat] + Time.deltaTime;
                beat.transform.position = Vector3.Lerp(m_leftSpawnPoint.position, m_center, m_leftBeatInstances[beat] / m_timeToCenter);

                if (m_leftBeatInstances[beat] / m_timeToCenter >= 1.0f)
                {
                    toRemove.Add(beat);
                }
            }
            foreach (VisualBeat beat in toRemove)
            {
                m_leftBeatInstances.Remove(beat);
                m_beatPool.Release(beat);
            }

            toRemove.Clear();
            foreach (VisualBeat beat in m_rightBeatInstances.Keys.ToArray())
            {
                m_rightBeatInstances[beat] = m_rightBeatInstances[beat] + Time.deltaTime;
                beat.transform.position = Vector3.Lerp(m_rightSpawnPoint.position, m_center, m_rightBeatInstances[beat] / m_timeToCenter);

                if (m_rightBeatInstances[beat] / m_timeToCenter >= 1.0f)
                {
                    toRemove.Add(beat);
                }
            }
            foreach (VisualBeat beat in toRemove)
            {
                m_rightBeatInstances.Remove(beat);
                m_beatPool.Release(beat);
            }

        }

        private void UpdateCurrentVisualBeat()
        {
            if (m_source.timeSamples == 0)
                return;

            m_sampleDelta += m_source.timeSamples - m_samplesLastFrame;
            int tmp = m_samplesLastFrame;
            m_samplesLastFrame = m_source.timeSamples;

            if (m_sampleDelta / m_samplesPerBeat >= 1)
            {
                m_sampleDelta -= m_samplesPerBeat;
                m_beatCount++;

                if (m_beatCount == m_currentBar.BeatAmount)
                {
                    m_beatCount = 0;
                    m_barCount++;
                    m_currentBar = new MusicBar(m_data.SheetData[m_barCount, 0], m_data.SheetData[m_barCount, 1], m_data.SheetData[m_barCount, 2]);
                    m_samplesPerBeat = (60f / m_currentBar.BPM) * m_sampleRate;
                }

                SpawnBeat();
            }
        }

        private void SpawnBeat()
        {
            if (m_currentBar.IsPause)
                return;

            VisualBeat leftBeat = m_beatPool.Acquire();
            leftBeat.transform.position = m_leftSpawnPoint.position;
            m_leftBeatInstances.Add(leftBeat, 0.0f);

            VisualBeat rightBeat = m_beatPool.Acquire();
            rightBeat.transform.position = m_rightSpawnPoint.position;
            m_rightBeatInstances.Add(rightBeat, 0.0f);
        }

        private void TrackStarted(SoundData _soundData)
        {
        }

        private void BeatDropper(BeatInfo _beat)
        {
        }
    }
}
