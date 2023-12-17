using GameState;
using UnityEngine;

namespace UI
{
    public class CursorState : MonoBehaviour
    {
        private void Awake()
        {
            Config.IsCursorVisible.OnValueChanged += ToggleCursor;
        }

        private void Start()
        {
            Config.IsCursorVisible.Vote(false, "Default state");
        }

        private void ToggleCursor(bool _previous, bool _current)
        {
            Cursor.visible = _current;
        }
    }
}
