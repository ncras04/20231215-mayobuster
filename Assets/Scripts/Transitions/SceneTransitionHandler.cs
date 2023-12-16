using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Transition
{
    public class SceneTransitionHandler : MonoBehaviour
    {
        public event System.Action<float> OnTransitionStart
        {
            add
            {
                onTransitionStart -= value;
                onTransitionStart += value;
            }
            remove
            {
                onTransitionStart -= value;
            }
        }
        public event System.Action OnTransitionEnd
        {
            add
            {
                onTransitionEnd -= value;
                onTransitionEnd += value;
            }
            remove
            {
                onTransitionEnd -= value;
            }
        }

        [SerializeField]
        private float transitionDuration = 2.0f;

        private string sceneToLoad = string.Empty;
        private Coroutine loadRoutine = null;

        private event System.Action<float> onTransitionStart;
        private event System.Action onTransitionEnd;

        public void StartTransition(string scene)
        {
            // already loading, skipping request
            if (loadRoutine != null)
                return;

            sceneToLoad = scene;
            onTransitionStart?.Invoke(transitionDuration);

            loadRoutine = StartCoroutine(EndTransition());
        }

        private IEnumerator EndTransition()
        {
            yield return new WaitForSecondsRealtime(transitionDuration);

            loadRoutine = null;
            onTransitionEnd?.Invoke();
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}