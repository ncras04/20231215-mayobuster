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

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}