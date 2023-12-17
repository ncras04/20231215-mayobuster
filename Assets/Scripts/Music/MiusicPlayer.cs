using GameState;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Member;

public struct MusicBar
{
    public int BeatAmount;
    public bool IsPause;
    public int BPM;

    public MusicBar(int _a, int _b, int _c)
    {
        BeatAmount = _a;
        IsPause = _b == 1;
        BPM = _c;
    }
}

public struct BeatInfo
{
    public int CurrentBPM;
    public int BarCount;
    public int BeatCount;

    public BeatInfo(int _a, int _b, int _c)
    {
        CurrentBPM = _a;
        BarCount = _b;
        BeatCount = _c;
    }
}

[RequireComponent(typeof(AudioSource))]
public class MiusicPlayer : MonoBehaviour
{
    public SoundData Track => m_track;
    
    [SerializeField]
    private SoundData m_track;

    private AudioSource m_source;

    public event Action<BeatInfo> BeatDropped;

    public event Action<SoundData> TrackStarted;

    private MusicBar m_currentBar;
    private int m_barCount = 0;
    private int m_beatCount = 0;
    private float m_samplesPerBeat;
    private float m_sampleDelta = 0;
    private int m_samplesLastFrame = 0;
    private int m_sampleRate;

    [SerializeField]
    TextMeshProUGUI hd;
    [SerializeField]
    private GameManager m_gameManager = null;

    private void Awake()
    {
        var audioConfig = AudioSettings.GetConfiguration();
        m_sampleRate = audioConfig.sampleRate;
        m_source = GetComponent<AudioSource>();
        m_source.playOnAwake = false;
        m_source.Stop();

        m_gameManager.OnStartGame += StartPlayback;
        m_gameManager.OnGameOver += StopPlayback;
    }

    void Start()
    {
        m_source.clip = m_track.SongFile;
        m_currentBar = new MusicBar(m_track.SheetData[m_barCount, 0], m_track.SheetData[m_barCount, 1], m_track.SheetData[m_barCount, 2]);

        m_samplesPerBeat = (60f / m_currentBar.BPM) * m_sampleRate;
    }

    void Update()
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
                m_currentBar = new MusicBar(m_track.SheetData[m_barCount, 0], m_track.SheetData[m_barCount, 1], m_track.SheetData[m_barCount, 2]);
                m_samplesPerBeat = (60f / m_currentBar.BPM) * m_sampleRate;
            }

            BeatDropped?.Invoke(new BeatInfo(m_currentBar.BPM, m_barCount, m_beatCount));

        }

        hd.text = m_currentBar.BeatAmount + " " + m_beatCount;
    }

    private void StopPlayback()
    {
        StartCoroutine(FadeOutMusic());
    }

    private void StartPlayback()
    {
        m_source.Play();
        TrackStarted?.Invoke(m_track);
    }

    private void CurrentStateChanged(bool _old, bool _new)
    {
        if (_new)
        {
            m_source.Pause();
        }
        else
        {
            m_source.Play();
        }
    }

    private IEnumerator FadeOutMusic()
    {
        float time = 0.0f;
        float currentVolume = m_source.volume;
        while (time < 1)
        {
            m_source.volume = Mathf.Lerp(currentVolume, 0.0f, time);
            time += Time.unscaledDeltaTime * 5;
            yield return null;
        }

        m_source.Stop();
        m_source.volume = 1.0f;
    }
}
