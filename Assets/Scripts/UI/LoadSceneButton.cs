using Transition;
using UnityEngine;

namespace UI
{
    [DisallowMultipleComponent]
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField]
        private SceneTransitionHandler transitionHandler = null;
        public void LoadScene(string scene)
        {
            transitionHandler.StartTransition(scene);
        }
    }
}