using GameState;
using UnityEngine;

namespace UI
{
    public class ShowEndScreen : MonoBehaviour
    {
        [SerializeField]
        private RectTransform uiPanel = null;

        private void Awake()
        {
            Config.CurrentState.OnValueChanged += ToggleEndScreen;
        }

        private void ToggleEndScreen(EGameState old, EGameState current)
        {
            if (current == EGameState.GAME_OVER)
            {
                uiPanel.gameObject.SetActive(true);
            }
            else if (old  == EGameState.GAME_OVER && current != EGameState.GAME_OVER) 
            {
                uiPanel.gameObject.SetActive(false);
            }
        }
    }
}