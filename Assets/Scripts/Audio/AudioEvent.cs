using UnityEngine;

namespace Audio
{
    public enum EMixerOutput
    {
        MAIN,
        BGM,
        SFX,
    }

    [CreateAssetMenu(fileName = "New AudioEvent", menuName = "Data/Audio/AudioEvent", order = 0)]
    public class AudioEvent : ScriptableObject
    {
        public int LastPlayedClip => m_lastClipPlayed;
        public float Volume => m_volume;
        public AudioClip[] Clips => m_clips;
        public bool IsPitchAffected => m_isPitchAffected;
        public EMixerOutput MixerOutput => m_mixerOutput;

        [SerializeField]
        [Range(0, 1)]
        private float m_volume = 1.0f;
        [SerializeField]
        private AudioClip[] m_clips;
        [SerializeField]
        private bool m_isPitchAffected;
        //[SerializeField]
        private EMixerOutput m_mixerOutput;
        private int m_lastClipPlayed = 0;

        public void SetLastClipPlayed(int _clip)
        {
            m_lastClipPlayed = _clip;
        }
    }
}
