using System;

namespace LeandroExhumed.SpaceChaos.Player
{
    public class ScoreModel : IScoreModel
    {
        public event Action<int> OnScoreChanged;
        public event Action OnAdvancedScoreReached;

        public int Score
        {
            get => score;
            set
            {
                score = value;
                OnScoreChanged?.Invoke(value);
            }
        }

        private bool isAdvanced = false;
        private int pointsToReward = 10000;
        private int pointsToAdvancedScore = 40000;

        private int score;

        public void Initialize ()
        {
            Score = 0;
        }

        public void AddPoints (int points)
        {
            Score += points;
            if (Score >= pointsToReward)
            {
                pointsToReward += 10000;
            }

            if (!isAdvanced && Score >= pointsToAdvancedScore)
            {
                isAdvanced = true;
                OnAdvancedScoreReached?.Invoke();
            }
        }
    }
}