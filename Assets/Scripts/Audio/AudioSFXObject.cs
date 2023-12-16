using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSFXObject : MonoBehaviour
    {
        public AudioSource Source => m_source;
        public IObjectPool<GameObject> Pool { get => m_pool; set => m_pool = value; }

        private AudioSource m_source;
        private IObjectPool<GameObject> m_pool;

        private void Awake()
        {
            m_source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Transform parent;

            if (transform.parent is not null)
            {
                parent = transform.parent;

                if (!parent.GetComponent<AudioSourceSaver>())
                    parent.AddComponent<AudioSourceSaver>();
            }
        }

        private void Update()
        {
            if (m_source.isPlaying)
                return;

            OnReturnToPool();
        }
        private void OnReturnToPool()
        {
            if (m_pool is not null)
            {
                transform.SetParent(null);
                m_pool.Release(gameObject);
            }
        }
    }
}
