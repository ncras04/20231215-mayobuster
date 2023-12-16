using GameState;
using UnityEngine;

namespace UI
{
    public class ShowEndScreen : MonoBehaviour
    {
        [SerializeField]
        private RectTransform uiPanel = null;
        [SerializeField]
        private GameManager m_gameManager = null;
        private void Awake()
        {
            m_gameManager.OnGameOver += DisplayEndScreen;
        }

        private void DisplayEndScreen()
        {
            uiPanel.gameObject.SetActive(true);
        }
    }
}