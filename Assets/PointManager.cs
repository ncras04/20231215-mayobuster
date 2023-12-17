using GameState;
using QuickTime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Tetris;
using UnityEngine;
using UnityEngine.Events;

public class PointManager : MonoBehaviour
{
    public Action<BigInteger> ScoreChanged;

    public BigInteger Points
    {
        get
        {
            return m_points;
        }
        set
        {
            if (m_points != value)
            {
                m_points = value;
                Debug.Log(m_points);
                ScoreChanged?.Invoke(m_points);
            }
        }
    }

    private BigInteger m_points = 0;

    [SerializeField]
    private int m_basePoints = 100;
    [SerializeField]
    private int baseMultiplier = 1000;

    private int m_deltaAccumulator = 0;

    private bool m_rightKnob = false;
    private int m_knobPoints = 50;
    private bool m_beatPoints = false;

    private bool m_noMorePoints = false;


    private void OnEnable()
    {
        FindObjectOfType<RightKnobTemperature>().IsMultiplyChanged += OnRightKnobMultiplyChanged;
        FindObjectOfType<GameManager>().OnGameOver += OnGameOver;
        FindObjectOfType<QuickTimeHandler>().OnQuickTimeEventFinished += OnQuickTimeFinished;
        FindObjectOfType<BowlManager>().OnBowlFinish.AddListener(OnBowlFinished);
        FindObjectOfType<TetrisProvider>().OnFullLine += OnFullLine;
        FindObjectOfType<BeatChecker>().GotBeatPoint += OnBeatPoint;
    }

    private void OnGameOver()
    {
        m_noMorePoints = true;
    }

    private void OnBeatPoint(bool obj)
    {
        m_beatPoints = obj;
    }

    private void OnDisable()
    {
        FindObjectOfType<RightKnobTemperature>().IsMultiplyChanged -= OnRightKnobMultiplyChanged;
        FindObjectOfType<QuickTimeHandler>().OnQuickTimeEventFinished -= OnQuickTimeFinished;
        FindObjectOfType<BowlManager>().OnBowlFinish.RemoveListener(OnBowlFinished);
        FindObjectOfType<TetrisProvider>().OnFullLine -= OnFullLine;
        FindObjectOfType<BeatChecker>().GotBeatPoint -= OnBeatPoint;
    }

    private void OnFullLine()
    {
        Points += baseMultiplier * baseMultiplier;
    }

    private void OnBowlFinished(Bowl arg0)
    {
        Points += arg0.ParticleAmount * baseMultiplier;
    }

    private void OnQuickTimeFinished(AQuickTimeEvent _event)
    {
        var pawEvent = _event is CatPawnEvent;

        if (pawEvent)
            Points += 100000;
    }

    private void OnRightKnobMultiplyChanged(bool _obj)
    {
        m_rightKnob = _obj;
    }

    void Update()
    {
        if (m_noMorePoints)
            return;

        m_deltaAccumulator = (int)(Time.deltaTime * 10f);


        Points += m_deltaAccumulator + ((Convert.ToInt32(m_beatPoints) * m_basePoints) + (Convert.ToInt32(m_rightKnob) * m_knobPoints));
    }
}
