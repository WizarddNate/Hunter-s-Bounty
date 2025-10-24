using UnityEngine;
using TMPro;
using System;
public class Timer : MonoBehaviour
{

    float currentTime;

    public TextMeshProUGUI timerText;

    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = ("Time: " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());
    }
}
