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
    private RightKnobTemperature m_thermoManager;

    void Start()
    {
        m_thermoManager.TemperatureChanged += OnTemperatureChanged;
    }

    private void OnTemperatureChanged(float _currentAmount, int _maxAmount)
    {
        m_thermometer.fillAmount = _currentAmount / _maxAmount;
    }


}
