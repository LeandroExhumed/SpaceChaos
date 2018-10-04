using UnityEngine;
using UnityEngine.UI;

namespace SpaceChaos {
    /// <summary>
    /// Score system related to the points made in game.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/Score")]
    public class Score : MonoBehaviour {
        /// <summary>Current amount of points.</summary>
        private int _currentPoints;
        public int currentPoints {
            get { return _currentPoints; }
            private set {
                _currentPoints = value;

                scoreLabel.text = currentPoints.ToString();
            }
        }

        /// <summary>Whether the score is on a amount considered advanced.</summary>
        private bool isAdvanced = false;
        /// <summary>How many points have to be reached to gain a reward.</summary>
        private int pointsToReward = 10000;
        /// <summary>How many points have to be considered a great score.</summary>
        private int pointsToAdvancedScore = 40000;

        /// <summary>Event fired when player reaches a certain amount of points to get a reward.</summary>
        public event System.Action onRewardPoints;
        /// <summary>Event fired when player reaches a certain amount of points considered advanced.</summary>
        public event System.Action onAdvancedScore;

        /// <summary>Label that shows the player score.</summary>
        [SerializeField]
        private Text scoreLabel;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            currentPoints = 0;
        }

        /// <summary>
        /// Adds some amount of points to the score.
        /// </summary>
        /// <param name="points">The points scored.</param>
        public void addPoints (int points) {
            currentPoints += points;
            if (currentPoints >= pointsToReward) {
                onRewardPoints();
                pointsToReward += 10000;
            }

            if (!isAdvanced && currentPoints >= pointsToAdvancedScore) {
                onAdvancedScore();
            }
        }
    } 
}