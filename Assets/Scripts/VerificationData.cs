using System;
using UnityEngine;

public class VerificationData : MonoBehaviour, IVerificationData
{
    private GameCard _firstGameCard = null;
    private GameCard _secondGameCard = null;
    public event Action OnWinner;
    public event Action OnLossing;

    public void Verification(GameCard data)
    {
        if (_firstGameCard != null && _secondGameCard != null) return;
        else if(_firstGameCard == null) 
        {
            _firstGameCard = data;
            return;
        }
        else
        {
            if (_firstGameCard.IsOpen())
            {
                _secondGameCard = data;

                if (IsEqual()) WinningCombination();
                else LossingCombination();

                _firstGameCard = _secondGameCard = null;
            }
            else _firstGameCard = data;
        }
    }

    private void WinningCombination()
    {
        _firstGameCard.ChangeCardState(GameCard.CardState.Offside);
        _secondGameCard.ChangeCardState(GameCard.CardState.Offside);

        OnWinner?.Invoke();
    }

    private void LossingCombination()
    {
        _firstGameCard.Turn();
        _secondGameCard.Turn();

        OnLossing?.Invoke();
    }

    private bool IsEqual()
    {
        return Convert.ToInt32(_firstGameCard.CardNumber.text) == Convert.ToInt32(_secondGameCard.CardNumber.text);
    }
}
