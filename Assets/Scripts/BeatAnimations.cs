using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatAnimations : MonoBehaviour
{
    [SerializeField]
    private MiusicPlayer m_player;

    private float m_songBPM = 0;
    private float m_currentBPMMultiplier = 1;
    private Vector3 m_scale;
    [SerializeField]
    [Range(1,3)]
    private float m_beatScale;
    [SerializeField]
    [Range(-1, 1)]
    private float m_sizeValue;

    private void OnEnable()
    {
        if (m_player is null)
            m_player = FindObjectOfType<MiusicPlayer>();

        m_player.TrackStarted += OnTrackStarted;
        m_player.BeatDropped += OnBeatDropped;
    }

    private void OnDisable()
    {
        m_player.TrackStarted -= OnTrackStarted;
        m_player.BeatDropped -= OnBeatDropped;
    }
    void Start()
    {
        m_scale = transform.localScale;
    }

    private void OnTrackStarted(SoundData data)
    {
        m_songBPM = data.SheetData[0, 2];
    }

    private void OnBeatDropped(BeatInfo info)
    {
        m_currentBPMMultiplier = info.CurrentBPM / m_songBPM;
        transform.localScale = m_scale * m_beatScale;
    }

    void Update()
    {
        if (transform.localScale.sqrMagnitude >= m_scale.sqrMagnitude)
        {
            transform.localScale -= m_scale * m_sizeValue * m_currentBPMMultiplier * Time.deltaTime;
        }
    }
}
