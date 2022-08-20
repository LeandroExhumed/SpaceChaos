using System;

namespace LeandroExhumed.SpaceChaos.Player
{
    public interface IScoreModel
    {
        event Action OnAdvancedScoreReached;
        event Action<int> OnScoreChanged;

        void AddPoints (int points);
        void Initialize ();
    }
}