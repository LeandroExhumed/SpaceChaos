using SpaceChaos.Constants;
using SpaceChaos.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceChaos.HUD {
    /// <summary>
    /// Panel that warns about game lost and show the current and the best score.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/HUD/GameOverPanel")]
    public class GameOverPanel : MonoBehaviour {
        /// <summary>Score system of the game.</summary>
        [SerializeField]
        private Score score;

        /// <summary>Text where will be shown the highest saved score achieved by player.</summary>
        [SerializeField]
        private Text highestScoreLabel;
        /// <summary>Text where will be shown the points achieved before player losing.</summary>
        [SerializeField]
        private Text currentScoreLabel;

        /// <summary>
        /// Called when object is enable in Inspector.
        /// </summary>
        private void OnEnable () {
            currentScoreLabel.text = score.currentPoints.ToString();
            checkHighScore();
        }

        /// <summary>
        /// Checks whether player has beaten its own score and shows it.
        /// </summary>
        private void checkHighScore () {
            int bestScoreSaved = DataService.load<int>(Paths.HIGH_SCORE_DATA);

            if (bestScoreSaved != 0) {
                if (score.currentPoints > bestScoreSaved) {
                    DataService.save(Paths.HIGH_SCORE_DATA, score.currentPoints);
                    highestScoreLabel.text = score.currentPoints.ToString();
                } else {
                    highestScoreLabel.text = bestScoreSaved.ToString();
                }
                
            } else {
                DataService.save(Paths.HIGH_SCORE_DATA, score.currentPoints);
                highestScoreLabel.text = score.currentPoints.ToString();
            }
        }
    }
}