using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMenuPanel : MonoBehaviour
{
    [SerializeField] private Text _playerLevel;
    [SerializeField] private Text _gameLevel;
    [SerializeField] private Text _money;
    [SerializeField] private Text _points;
    [SerializeField] private Button _startButton;

    public event Action<Button> GameRepeating;

    public void ShowEndGameMenu(int playerLevel, int gameLevel, int points)
    {
        _playerLevel.text = playerLevel.ToString();
        _gameLevel.text = gameLevel.ToString();
        _money.text = (points * 15 * playerLevel).ToString();
        _points.text = points.ToString();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RepeatGame()
    {
        GameRepeating?.Invoke(_startButton);
        gameObject.SetActive(false);
    }
}
