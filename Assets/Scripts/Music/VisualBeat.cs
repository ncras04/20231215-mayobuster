using Helpers;
using UnityEngine;

namespace Music
{

    public class VisualBeat : MonoBehaviour, IPoolObject
    {
        [SerializeField]
        private SpriteRenderer m_renderer = null;

        public void Acquire()
        {
            m_renderer.enabled = true;
        }

        public void Reclaim()
        {
            m_renderer.enabled = false;
        }

        public void SetSide(bool _isLeft)
        {
            m_renderer.flipX = _isLeft;
        }
    }

}