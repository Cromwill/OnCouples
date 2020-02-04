using System;

interface IVerificationData
   {
    event Action OnWinner;
    event Action OnLossing;
    void Verification(GameCard data);
   }

