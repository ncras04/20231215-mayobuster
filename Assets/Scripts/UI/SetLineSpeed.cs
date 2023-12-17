using GameState;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

    public class SetLineSpeed : MonoBehaviour
    {
        [SerializeField]
        private Slider m_slider = null;

        private void OnEnable()
        {
            m_slider.value = Config.LineSpeed;
        }

        public void SetLineSpeedValue(float _value)
        {
            Config.LineSpeed = (int)_value;
        }
    }
}
