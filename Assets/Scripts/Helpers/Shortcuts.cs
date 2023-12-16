using GameState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    public class Shortcuts : MonoBehaviour
    {
        [SerializeField]
        private GameManager m_gameManager = null;

        // Update is called once per frame
        void Update()
        {
            if (!Input.GetKey(KeyCode.LeftShift))
                return;
            if (Input.GetKeyDown(KeyCode.S))
            {
                m_gameManager.StartGame();
            }
        }
    }
}