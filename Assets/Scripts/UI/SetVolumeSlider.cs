using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class SetVolumeSlider : MonoBehaviour
    {
        [SerializeField]
        private Slider slider = null;
        [SerializeField]
        private string category = string.Empty;
        [SerializeField]
        private AudioMixer masterMixer = null;

        private void OnEnable()
        {
            if (masterMixer.GetFloat(category, out float volume))
            {
                slider.value = volume;
            }
        }

        public void SetVolume(float _volume)
        {
            masterMixer.SetFloat(category, _volume);
        }
    }
}