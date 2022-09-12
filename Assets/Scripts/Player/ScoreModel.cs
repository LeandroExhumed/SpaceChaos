using LeandroExhumed.SpaceChaos.Session;
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
        private int pointsToReward;

        private readonly SessionData sessionData;

        private int score;

        public ScoreModel (SessionData sessionData)
        {
            this.sessionData = sessionData;
        }

        public void Initialize ()
        {
            Score = 0;
            pointsToReward = sessionData.StartScoreToReward;
        }

        public void AddPoints (int points)
        {
            Score += points;
            if (Score >= pointsToReward)
            {
                pointsToReward += 10000;
            }

            if (!isAdvanced && Score >= sessionData.AdvancedScore)
            {
                isAdvanced = true;
                OnAdvancedScoreReached?.Invoke();
            }
        }
    }
}