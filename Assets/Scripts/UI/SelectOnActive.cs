using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class SelectOnActive : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_toSelect = null;

        private void OnEnable()
        {
            EventSystem.current.SetSelectedGameObject(m_toSelect);
        }
    }
}
