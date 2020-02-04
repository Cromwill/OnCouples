using System;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanelDrawer : MonoBehaviour
{
    [SerializeField] private Text _gameLevel;
    [SerializeField] private Text _gameTry;
    [SerializeField] private Text _gamePoints;

    public void UpdateDisplayUI(InformationPanel gameData)
    {
        _gameLevel.text = gameData.GameLevel.ToString();
        _gameTry.text = gameData.GameTry.ToString();
        _gamePoints.text = gameData.GamePoints.ToString();
    }
}