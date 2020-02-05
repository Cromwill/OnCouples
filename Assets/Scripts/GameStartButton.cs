using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    [SerializeField] private float CountdownTime;

    private Button _selfButton;
    private Text _text;
    private ITimer _timer;
    private float _showCountdownTime;

    private void Start()
    {
        _selfButton = GetComponent<Button>();
        _text = GetComponentInChildren<Text>();
        _timer = new Timer();
    }

    private void Update()
    {
        if(_timer.Countdown(Time.deltaTime))
        {
            _text.text = _timer.ShowTimeInMinutes();
        }
        else
        {
            _text.text = "Play";
            _selfButton.interactable = true;
        }
    }

    public void RepeatGame()
    {
        _selfButton.interactable = false;
        _showCountdownTime = CountdownTime;
        _timer.StartTimer(CountdownTime);
    }

}
