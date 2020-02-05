using UnityEngine;
using System;

public class Timer : ITimer
{
    private float _countdownTime;
    public float _currentTime;

    public bool IsTimerRunning { get; private set; }
    
    public Timer()
    {
        IsTimerRunning = false;
    }
       
    public void StartTimer(float leftTime)
    {
        if (!IsTimerRunning)
        {
            _currentTime = leftTime;
            IsTimerRunning = true;
        }
    }

    public bool Countdown(float time)
    {
        _currentTime -= time;
        if (_currentTime < 0) IsTimerRunning = false;

        return IsTimerRunning;
    }

    public string ShowTimeInSeconds()
    {
        return Mathf.FloorToInt(_currentTime).ToString();
    }

    public string ShowTimeInMinutes()
    {
        int min = (int)(_currentTime / 60.0f);
        int sec = (int)(_currentTime % 60.0f);

        return  String.Format("{0} : {1}", min, sec);
    }
}
