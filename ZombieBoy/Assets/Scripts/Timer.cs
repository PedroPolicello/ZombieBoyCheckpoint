using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    [SerializeField] private float choosedTime;
    private float totalTime;

    [SerializeField] private TextMeshProUGUI timerText;
    private float time;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        totalTime = choosedTime;
    }

    void Update()
    {
        time += Time.deltaTime;
        float remainingTime = totalTime - time;


        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        string minutesString = minutes.ToString("D2");
        string secondsString = seconds.ToString("D2");

        timerText.text = (minutesString + ":" + secondsString);

        if (remainingTime <= 0)
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }

    }

}