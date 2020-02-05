using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New levels StartData", menuName ="StartData")]
public class GameData : ScriptableObject
{
    [SerializeField] private int _gameLevel;
    [SerializeField] private int _gameTry;
    [SerializeField] private int _gamePoints;
    [SerializeField] private int _cardAmount;

    public int GameLevel { get => _gameLevel;}
    public int GameTry { get => _gameTry;}
    public int GamePoints { get => _gamePoints;}
    public int CardAmount { get => _cardAmount;}
}
