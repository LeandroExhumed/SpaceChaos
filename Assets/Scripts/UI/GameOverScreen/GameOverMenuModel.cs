using SpaceChaos.Constants;
using SpaceChaos.Utils;
using System;

namespace LeandroExhumed.SpaceChaos.UI.GameOverScreen
{
    public class GameOverMenuModel : IGameOverMenuModel
    {
        public event Action<int, int> OnSetup;

        public void Setup (int points)
        {
            int bestScoreSaved = DataService.load<int>(Paths.HIGH_SCORE_DATA);

            if (bestScoreSaved != 0)
            {
                if (points > bestScoreSaved)
                {
                    DataService.save(Paths.HIGH_SCORE_DATA, points);
                    bestScoreSaved = points;
                }
            }
            else
            {
                DataService.save(Paths.HIGH_SCORE_DATA, points);
                bestScoreSaved = points;
            }

            OnSetup?.Invoke(points, bestScoreSaved);
        }

        public void QuitToMainMenu () => SceneLoader.LoadMainMenu();
    }
}