using UnityEngine;

namespace Audio
{
    public class PlaySFX : MonoBehaviour
    {
        [SerializeField]
        private SoundFXRequestCollection m_sfxRequestCollection = null;
        [SerializeField]
        private AudioEvent m_audioEvent = null;

        private void Start()
        {
            m_sfxRequestCollection.Add(AudioSFX.Request(m_audioEvent));
        }
    }
}
