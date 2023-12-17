using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class RightKnobTemperature : MonoBehaviour
{
    public event Action<bool> IsMultiplyChanged;

    public event Action<float, int> TemperatureChanged;

    [SerializeField]
    private int m_moduloRandomizer;
    [SerializeField]
    private int m_maxRND;
    private int m_rnd = 0;
    private float m_changeAmount;
    private int m_maxAmount = 100;
    private int m_normal = 10;
    private float m_currentAmount;
    private bool m_currentBool = true;

    [SerializeField]
    private float m_knobSens = 1;

    [SerializeField]
    [Range(0, 1)]
    private float m_changeSense = 1;

    private void Awake()
    {
        m_currentAmount = m_maxAmount - m_normal;
    }

    private void Update()
    {
        if (!m_currentBool == (m_currentAmount > m_maxAmount - (m_normal * 2) && m_currentAmount < m_maxAmount - (m_normal * 0.5f)))
        {
            m_currentBool = !m_currentBool;
            IsMultiplyChanged?.Invoke(m_currentBool);
        }
    }
    void FixedUpdate()
    {
        m_rnd = UnityEngine.Random.Range(0, m_maxRND);

        if (m_rnd % m_moduloRandomizer == 0)
        {
            m_changeAmount = UnityEngine.Random.Range(m_maxAmount / 1000f, m_maxAmount / 200f);
            Debug.Log(m_changeAmount);

            if (m_rnd > m_maxRND / 2)
            {
                StopAllCoroutines();
                StartCoroutine(ChangeTemp(m_changeAmount));
            }
            else
            {
                StopAllCoroutines();
                StartCoroutine(ChangeTemp(-m_changeAmount));
            }
        }
    }

    IEnumerator ChangeTemp(float _value)
    {
        while (true)
        {
            m_currentAmount += _value * m_changeSense * 0.1f;
            TemperatureChanged.Invoke(m_currentAmount, m_maxAmount);
            yield return null;
        }
    }

    public void OnRightKnob(InputAction.CallbackContext _ctx)
    {
        m_currentAmount -= _ctx.ReadValue<Vector2>().y * m_knobSens;
        m_currentAmount = Mathf.Clamp(m_currentAmount, 0, 100);
        TemperatureChanged.Invoke(m_currentAmount, m_maxAmount);
    }

}
