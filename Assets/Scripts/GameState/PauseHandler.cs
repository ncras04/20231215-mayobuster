using UnityEngine;

namespace GameState
{
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject pauseScreen = null;

        private void Awake()
        {
            Config.CurrentState.OnValueChanged += ChangeState;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Config.CurrentState.Value != EGameState.PAUSED)
                {
                    Config.CurrentState.Vote(EGameState.PAUSED, "Button pressed");
                }
                else
                {
                    Config.CurrentState.Revoke(EGameState.PAUSED, "Button pressed");
                }
            }
        }

        public void ContinueGame()
        {
            Config.CurrentState.Revoke(EGameState.PAUSED, "Button pressed");
        }

        private void ChangeState(EGameState old, EGameState current)
        {
            if (current == EGameState.PAUSED)
            {
                pauseScreen.SetActive(true);
            }
            else if (old == EGameState.PAUSED)
            {
                pauseScreen.SetActive(false);
            }
        }
    }
}