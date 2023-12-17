using QuickTime;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DeadCatsDisplay : MonoBehaviour
    {
        public int CurrentScore
        {
            get => m_currentScore;
            set
            {
                if (m_currentScore == value)
                    return;
                m_currentScore = value;
                DisplayScore();
            }
        }

        [SerializeField]
        private QuickTimeHandler m_quickTimeHandler = null;
        [SerializeField]
        private TextMeshProUGUI m_label = null;

        private int m_currentScore = 0;

        private void Awake()
        {
            m_quickTimeHandler.OnQuickTimeEventFinished += CheckForCatEvent;
        }

        private void CheckForCatEvent(AQuickTimeEvent _event)
        {
            if (_event is CatPawnEvent)
            {
                CurrentScore++;
            }
        }

        private void DisplayScore()
        {
            m_label.SetText(CurrentScore.ToString("000"));
        }
    }
}
