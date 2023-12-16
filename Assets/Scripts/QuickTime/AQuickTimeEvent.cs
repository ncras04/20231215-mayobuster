using GameState;
using UnityEngine;

namespace QuickTime
{
    public abstract class AQuickTimeEvent : MonoBehaviour
    {
        public abstract void Initialize(GameManager _gameManager);
        public abstract bool UpdateEvent();
        public abstract void Deinitialize();
    }
}
