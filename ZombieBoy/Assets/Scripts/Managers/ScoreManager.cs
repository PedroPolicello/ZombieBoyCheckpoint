using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreUI;
    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (score >= 15)
        {
            Time.timeScale = 0;
        }
    }

    public void AddScore(int point)
    {
        score += point;
        SetScore();
    }

    private void SetScore()
    {
        scoreUI.text = score.ToString() + "/15";
    }
}