using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Temperatur : MonoBehaviour
{
    [SerializeField]
    private Image m_thermometer;

    [SerializeField]
    private Image m_niceThermos;

    [SerializeField]
    private RightKnobTemperature m_thermoManager;

    void OnEnable()
    {
        m_thermoManager.TemperatureChanged += OnTemperatureChanged;
        m_thermoManager.IsMultiplyChanged += OnMultiplyChanged;
    }

    private void OnDisable()
    {
        m_thermoManager.TemperatureChanged -= OnTemperatureChanged;
        m_thermoManager.IsMultiplyChanged -= OnMultiplyChanged;
    }

    private void OnMultiplyChanged(bool _obj)
    {
        m_niceThermos.gameObject.SetActive(_obj);
    }

    private void OnTemperatureChanged(float _currentAmount, int _maxAmount)
    {
        m_thermometer.fillAmount = _currentAmount / _maxAmount;
    }


}
