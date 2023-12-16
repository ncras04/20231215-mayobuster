using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "New MusicEvent", menuName = "Data/Audio/MusicEvent", order = 0)]
    public class MusicEvent : ScriptableObject
    {
        public float Volume => m_volume;
        public AudioClip Song => m_song;

        [SerializeField]
        [Range(0, 1)]
        private float m_volume = 1.0f;
        [SerializeField]
        private AudioClip m_song;
    }
}
