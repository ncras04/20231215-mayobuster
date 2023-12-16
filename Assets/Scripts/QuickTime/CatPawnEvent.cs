using Audio;
using GameState;
using Helpers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace QuickTime
{
    public class CatPawnEvent : AQuickTimeEvent
    {
        [SerializeField]
        private SpriteRenderer m_spriteRenderer = null;
        [SerializeField]
        private List<Sprite> m_catPawnSprites = new List<Sprite>();
        [SerializeField]
        private SoundFXRequestCollection m_sfxRequestCollection = null;
        [SerializeField]
        private AudioEvent m_hitEvent = null;
        [SerializeField]
        private AudioEvent m_spawnEvent = null;
        [SerializeField]
        private Transform m_pawPivot = null;
        [SerializeField]
        private Vector2 m_movementSpeedRange = new Vector2(2.0f, 5.0f);
        [SerializeField]
        private float m_minDistanceToBowl = 5.0f;

        private Bowl m_bowl = null;
        private bool m_isLeft = false;
        private bool m_isDead = false;
        private Camera m_camera = null;
        private GameManager m_gameManager = null;
        private float m_movementSpeed = 0.0f;

        private void Awake()
        {
            m_camera = Camera.main;

            PlayerInput.all[0].currentActionMap.FindAction("FX-Button L").performed += LeftButtonPressed;
            PlayerInput.all[0].currentActionMap.FindAction("FX-Button R").performed += RightButtonPressed;
        }

        private void LeftButtonPressed(InputAction.CallbackContext _context)
        {
            if (!m_isLeft)
                return;

            m_sfxRequestCollection.Add(AudioSFX.Request(m_hitEvent));
            m_isDead = true;
        }

        private void RightButtonPressed(InputAction.CallbackContext _context)
        {
            if (m_isLeft)
                return;

            m_sfxRequestCollection.Add(AudioSFX.Request(m_hitEvent));
            m_isDead = true;
        }

        public override void Deinitialize()
        {
            Destroy(this.gameObject);
        }

        public override void Initialize(GameManager _gameManager)
        {
            m_bowl = FindObjectOfType<Bowl>(true);
            if (m_bowl == null)
                return;

            m_gameManager = _gameManager;
            m_spriteRenderer.enabled = true;
            m_spriteRenderer.sprite = m_catPawnSprites.Random();
            m_sfxRequestCollection.Add(AudioSFX.Request(m_spawnEvent));

            m_isLeft = Random.Range(0, 2) == 0;
            if (m_isLeft)
                m_pawPivot.localEulerAngles = new Vector3(0, 180, 0);

            SetPosition();

            m_movementSpeed = Random.Range(m_movementSpeedRange.x, m_movementSpeedRange.y);
        }

        public override bool UpdateEvent()
        {
            if (m_bowl == null)
                return true;

            if (m_isDead)
                return true;

            Vector3 direction = m_bowl.transform.position - transform.position;
            direction = direction.normalized * Time.deltaTime * m_movementSpeed;
            transform.position += direction;

            if (Vector3.SqrMagnitude(transform.position - m_bowl.transform.position) < m_minDistanceToBowl * m_minDistanceToBowl)
            {
                m_bowl.transform.position += direction;
            }

            Vector3 bowlOnScreen = m_camera.WorldToScreenPoint(m_bowl.transform.position);
            if (bowlOnScreen.x < 0 || bowlOnScreen.x > Screen.width)
            {
                m_gameManager.EndGame();
            }

            return false;
        }

        private void SetPosition()
        {
            Vector3 spawnPos;
            if (m_isLeft)
            {
                spawnPos = m_camera.ScreenToWorldPoint(new Vector3(-100, 0, 0));
            }
            else
            {
                spawnPos = m_camera.ScreenToWorldPoint(new Vector3(Screen.width + 100, 0, 0));
            }
            spawnPos.z = 0;
            spawnPos.y = m_bowl.transform.position.y;

            transform.position = spawnPos;
        }
    }
}
