using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    public class ObjectPool<T> where T : MonoBehaviour, IPoolObject
    {
        private T prefab { get; set; }

        private Stack<T> pool = new Stack<T>();
        private List<T> active = new List<T>();

        public ObjectPool(T prefab, int initialSize)
        {
            this.prefab = prefab;

            T instance;
            for (int i = 0; i < initialSize; i++)
            {
                instance = GameObject.Instantiate(prefab);
                instance.Reclaim();

                pool.Push(instance);
            }
        }

        public void ForceReleaseAll()
        {
            T[] instances = active.ToArray();
            foreach (T instance in instances)
            {
                Release(instance);
            }
        }

        public T Acquire()
        {
            T instance;
            if (pool.Count > 0)
            {
                instance = pool.Pop();
            }
            else
            {
                instance = GameObject.Instantiate(prefab);
            }
            instance.Acquire();
            active.Add(instance);
            return instance;
        }

        public void Release(T _instance)
        {
            _instance.Reclaim();
            pool.Push(_instance);
            active.Remove(_instance);
        }
    }
}
