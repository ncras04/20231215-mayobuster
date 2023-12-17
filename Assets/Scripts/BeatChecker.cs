using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

public class BeatChecker : MonoBehaviour
{
    private MiusicPlayer m_player;

    [SerializeField]
    SoundFXRequestCollection m_collection;

    [SerializeField]
    AudioEvent m_sound;

    [SerializeField]
    Transform m_bottlePos;

    [SerializeField]
    Transform m_leftPos;
    [SerializeField]
    Transform m_rightPos;

    public Action<bool> GotBeatPoint;

    private int m_lastMaximum;
    private int m_currentMaximum;

    


    private void OnEnable()
    {
        if (m_player is null)
            m_player = FindObjectOfType<MiusicPlayer>();

        m_player.BeatDropped += OnBeatDropped;
    }

    private void Update()
    {
        if (m_bottlePos.position.x > m_rightPos.position.x)
        {
            m_currentMaximum = 1;
        }
        if (m_bottlePos.position.x < m_leftPos.position.x)
        {
            m_currentMaximum = -1;
        }
    }

    private void OnBeatDropped(BeatInfo info)
    {
        if (m_lastMaximum != m_currentMaximum)
        {
            GotBeatPoint.Invoke(true);
            m_lastMaximum = m_currentMaximum;
        }
        else
        {
            m_collection.Add(AudioSFX.Request(m_sound));
            GotBeatPoint.Invoke(false);
        }
    }
}
