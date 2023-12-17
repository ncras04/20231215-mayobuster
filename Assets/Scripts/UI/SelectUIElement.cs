using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class SelectUIElement : MonoBehaviour
    {
        public void SelectGameObject(GameObject _go)
        {
            EventSystem.current.SetSelectedGameObject(_go);
        }
    }
}
