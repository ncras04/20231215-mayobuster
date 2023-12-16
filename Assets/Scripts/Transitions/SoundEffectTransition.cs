using Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Transition
{
    public class SoundEffectTransition : MonoBehaviour
    {
        [SerializeField]
        private SoundFXRequestCollection m_sfxRequestCollection = null;
        [SerializeField]
        private SceneTransitionHandler m_sceneTransitionHandler = null;
        [SerializeField]
        private AudioEvent m_audioEvent = null;
        [SerializeField]
        private bool m_shouldPlayAtEnd = false;

        private void Awake()
        {
            m_sceneTransitionHandler.OnTransitionStart += PlaySFX;
        }

        private void PlaySFX(float _time)
        {
            if (!m_shouldPlayAtEnd)
            {
                m_sfxRequestCollection.Add(AudioSFX.Request(m_audioEvent));
            }
            else
            {
                float time = _time - m_audioEvent.Clips[0].length;
                if (time < 0)
                {
                    m_sfxRequestCollection.Add(AudioSFX.Request(m_audioEvent));
                }
                else
                {
                    StartCoroutine(DelayUntilEnd(time));
                }
            }
        }

        private IEnumerator DelayUntilEnd(float _time)
        {
            yield return new WaitForSecondsRealtime(_time);
            m_sfxRequestCollection.Add(AudioSFX.Request(m_audioEvent));
        }
    }

}