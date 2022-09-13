using System;

namespace LeandroExhumed.SpaceChaos.Player
{
    public interface IScoreModel
    {
        event Action<int> OnScoreChanged;
        event Action OnRewardWon;
        event Action OnAdvancedScoreReached;

        int Score { get; }

        void AddPoints (int points);
        void Initialize ();
    }
}