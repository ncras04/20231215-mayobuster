using GameState;
using Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickTime
{
    [DisallowMultipleComponent]
    public class QuickTimeHandler : MonoBehaviour
    {
        public event System.Action<AQuickTimeEvent> OnQuickTimeEventFinished
        {
            add
            {
                m_onQuickTimeEventFinished -= value;
                m_onQuickTimeEventFinished += value;
            }
            remove
            {
                m_onQuickTimeEventFinished -= value;
            }
        }

        [SerializeField]
        private Vector2 m_quickTimeInterval = Vector2.zero;
        [SerializeField]
        private List<AQuickTimeEvent> m_events = new List<AQuickTimeEvent>();
        [SerializeField]
        private GameManager m_gameManager = null;

        private AQuickTimeEvent m_currentEvent = null;
        private float m_timeLeft = 0.0f;
        private bool m_isPlaying = false;

        private event System.Action<AQuickTimeEvent> m_onQuickTimeEventFinished;

        private void Awake()
        {
            m_gameManager.OnStartGame += StartQuickTime;
            m_gameManager.OnGameOver += StopQuickTime;
        }

        private void StopQuickTime()
        {
            m_isPlaying = false;
        }

        private void StartQuickTime()
        {
            m_isPlaying = true;
        }

        private void Start()
        {
            m_timeLeft = Random.Range(m_quickTimeInterval.x, m_quickTimeInterval.y);
        }

        private void Update()
        {
            if (!m_isPlaying)
                return;

            if (m_currentEvent != null)
            {
                if (m_currentEvent.UpdateEvent())
                {
                    m_onQuickTimeEventFinished?.Invoke(m_currentEvent);
                    m_currentEvent.Deinitialize();
                    m_currentEvent = null;
                }
                return;
            }

            m_timeLeft -= Time.deltaTime;
            if (m_timeLeft < 0.0f)
            {
                m_timeLeft = Random.Range(m_quickTimeInterval.x, m_quickTimeInterval.y);
                m_currentEvent = Instantiate(m_events.Random());
                m_currentEvent.Initialize(m_gameManager);
            }
        }
    }
}