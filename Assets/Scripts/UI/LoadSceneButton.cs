using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    [DisallowMultipleComponent]
    public class LoadSceneButton : MonoBehaviour
    {
        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}