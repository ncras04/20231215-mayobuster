using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI m_text;

    private void Awake()
    {
        m_text = GetComponent<TextMeshProUGUI>();
        m_text.text = 0.ToString();
    }

    private void OnEnable()
    {
        FindObjectOfType<PointManager>().ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        FindObjectOfType<PointManager>().ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(BigInteger integer)
    {
        m_text.text = integer.ToString();
    }
}
