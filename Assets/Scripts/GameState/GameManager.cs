using Helpers;
using UnityEngine;

namespace GameState
{
    public class GameManager : MonoBehaviour
    {
        public event System.Action OnStartGame
        {
            add
            {
                m_onStartGame -= value;
                m_onStartGame += value;
            }
            remove
            {
                m_onStartGame -= value;
            }
        }
        public event System.Action OnGameOver
        {
            add
            {
                m_onGameOver -= value;
                m_onGameOver += value;
            }
            remove
            {
                m_onGameOver -= value;
            }
        }

        [SerializeField]
        private BowlManager m_bowlManager = null;

        private event System.Action m_onStartGame;
        private event System.Action m_onGameOver;

        private bool m_isRunning = false;

        private void Awake()
        {
            m_bowlManager.OnBowlReady.AddListener((bowl) => { if (!m_isRunning) StartGame(); });
        }

        public void StartGame()
        {
            m_isRunning = true;
            m_onStartGame?.Invoke();
        }

        public void EndGame()
        {
            m_isRunning = false;
            m_onGameOver?.Invoke();
        }
    }
}