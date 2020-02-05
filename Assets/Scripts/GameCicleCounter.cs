using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameCicleCounter : MonoBehaviour
{
    [SerializeField] private GameData _gameStartData;
    [SerializeField] private CardGenerator _cardGenerator;
    [SerializeField] private InformationPanelDrawer _informationPanelDrawer;
    [SerializeField] private GameObject _gameOverPanel;

    private InformationPanel _informationPanel;
    private IVerificationData _verification;
    private const int _tryAddingChangeLevel = 10;
    private const int _playerLevel = 1;

    private void Start()
    {
        _verification = GetComponentInChildren<IVerificationData>();
        _verification.OnLossing += SendDataForDrawerLosse;
        _verification.OnWinner += SendDataForDrawerWin;
    }

    public void StartGame(Button startBatton)
    {
        startBatton.gameObject.SetActive(false);
        _informationPanel = new InformationPanel(_gameStartData.GameLevel, _gameStartData.GameTry, _gameStartData.GamePoints, _informationPanelDrawer);
        _cardGenerator.Generate(_gameStartData.CardAmount + Difficulty());
    }

    private void RestartGame(Button startButton)
    {
        startButton.gameObject.SetActive(true);
        startButton.GetComponent<GameStartButton>().RepeatGame();
    }

    private void SendDataForDrawerWin()
    {
        _informationPanel.Change(InformationPanel.DataField.gamePoints, 1);
        QuantityCheck();
    }

    private void SendDataForDrawerLosse()
    {
        _informationPanel.Change(InformationPanel.DataField.gameTry, -1);
        if (_informationPanel.GameTry <= 0) GameOver();
    }

    private void GameOver()
    {
        _cardGenerator.ReGenerate(0);
        _gameOverPanel.SetActive(true);
        _gameOverPanel.GetComponent<EndGameMenuPanel>().ShowEndGameMenu(_playerLevel, _informationPanel.GameLevel, _informationPanel.GamePoints);
        _gameOverPanel.GetComponent<EndGameMenuPanel>().GameRepeating += RestartGame;
    }

    private void LevelVictory()
    {
        _informationPanel.Change(InformationPanel.DataField.GameLevel, 1);
        _informationPanel.Change(InformationPanel.DataField.gameTry, (_gameStartData.GameTry - _informationPanel.GameTry));

        if (_informationPanel.GameLevel >= _tryAddingChangeLevel)
            _informationPanel.Change(InformationPanel.DataField.gameTry, _informationPanel.GameLevel - _tryAddingChangeLevel + 1);

        _cardGenerator.ReGenerate(_gameStartData.CardAmount + Difficulty());
    }

    private void QuantityCheck()
    {
        if (_cardGenerator.IsCardsOpen())
            LevelVictory();
    }

    private int Difficulty()
    {
        return (_informationPanel.GameLevel - 1) * 2;
    }
}
