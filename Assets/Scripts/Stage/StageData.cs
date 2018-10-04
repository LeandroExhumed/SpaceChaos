using UnityEngine;

namespace SpaceChaos.Stage {
    /// <summary>
    /// All important data related to the stage.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/Stage/StageData")]
    public class StageData : MonoBehaviour {
        /// <summary>Current active stage.</summary>
        public int currentStage { get; private set; }

        /// <summary>Amount of asteroids on the first stage.</summary>
        [SerializeField]
        private int initialAsteroidsAmount = 4;
        /// <summary>Amount of asteroids on space on first level.</summary>
        public int asteroidsPerStage { get; private set; }

        /// <summary>The system responsible for checking all enemies of the stage..</summary>
        [SerializeField]
        private EnemyManager enemyManager;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            currentStage = 1;
            asteroidsPerStage = initialAsteroidsAmount;
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            enemyManager.onAsteroidsClear += () => advanceToNextStage();
        }

        /// <summary>
        /// Handles the stage data to the next one.
        /// </summary>
        public void advanceToNextStage () {
            currentStage++;
            asteroidsPerStage++;
        }
    } 
}