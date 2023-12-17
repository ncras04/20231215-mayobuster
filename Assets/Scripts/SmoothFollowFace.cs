using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SmoothFollowFace : MonoBehaviour
{
    [SerializeField]
    private Transform m_bottle;

    [SerializeField]
    private Image m_face;

    [SerializeField]
    private Animation m_anim;

    [SerializeField]
    private Sprite[] m_sprites;
    private int m_currentSprite = 0;

    [SerializeField]
    private Vector3 m_offset = Vector3.zero;

    private Vector3 m_velocity = Vector3.zero;
    private float m_smooth = 0.4f;

    private MiusicPlayer m_player;
    private int beat;

    private void OnEnable()
    {
        if (m_player is null)
            m_player = FindObjectOfType<MiusicPlayer>();

        m_player.BeatDropped += OnBeatDropped;

        m_face.sprite = m_sprites[m_currentSprite];
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, m_bottle.position - m_offset, ref m_velocity, m_smooth);
    }

    private void OnBeatDropped(BeatInfo info)
    {
        beat++;

        if(beat % 4 == 0)
        {
            m_face.sprite = m_sprites[RandomFace()];
        }
    }

    int RandomFace()
    {
        return UnityEngine.Random.Range(0, m_sprites.Length - 1);
    }
}
