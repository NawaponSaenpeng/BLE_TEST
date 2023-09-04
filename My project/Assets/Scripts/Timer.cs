using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{   
    [Header("Component")]
    public TMP_Text timerTextMinutes;
    public TMP_Text timerTextSeconds;

    
    private float timerTime;
    private bool isRunning;

    void Start()
    {
        isRunning = true;
    }

    void Update()
    {
        timerTime += Time.deltaTime;
        int minutesInt = (int)timerTime / 60;
        int secondsInt = (int)timerTime % 60;

        if (isRunning)
        {
            timerTextMinutes.text = (minutesInt < 10) ? "0" + minutesInt : minutesInt.ToString();
            timerTextSeconds.text = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString();
        }
    }
}
