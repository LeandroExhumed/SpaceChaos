using System;

namespace LeandroExhumed.SpaceChaos.Player
{
    public interface IScoreModel
    {
        event Action OnAdvancedScoreReached;
        event Action<int> OnScoreChanged;

        int Score { get; }

        void AddPoints (int points);
        void Initialize ();
    }
}