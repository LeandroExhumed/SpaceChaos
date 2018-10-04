using UnityEngine;

namespace SpaceChaos {
    /// <summary>
    /// Responsible for spawning the UFOs in match.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/Enemies/UFOSpawner")]
    public class UFOSpawner : MonoBehaviour {
        /// <summary>Limit position of game stage on X axis.</summary>
        private float stageLimitInX = 9;
        /// <summary>Limit position of game stage on Y axis.</summary>
        private float stageLimitInY = 2.5f;
        /// <summary>Whether player is advanced on score to filter the kind of UFO.</summary>
        private bool onAdvancedScore = false;

        /// <summary>Prefab of the small UFO.</summary>
        [SerializeField]
        private GameObject smallUFO;
        /// <summary>Prefab of the big UFO.</summary>
        [SerializeField]
        private GameObject bigUFO;

        /// <summary>The system responsible for checking all enemies of the stage.</summary>
        [SerializeField]
        EnemyManager enemyManager;
        /// <summary>Score system related to the points made in game.</summary>
        [SerializeField]
        private Score score;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            score.onAdvancedScore += filter;
        }

        /// <summary>
        /// Creates a new kind of UFO using the right configs.
        /// </summary>
        public void createUFO () {
            if (onAdvancedScore) {
                getNewUFO(smallUFO);
            } else {
                float probability = Random.value;
                if (probability > 0.5f) {
                    getNewUFO(bigUFO);
                } else {
                    getNewUFO(smallUFO);
                }
            }
        }

        /// <summary>
        /// Creates athe specified UFO.
        /// </summary>
        /// <param name="ufo">UFO category prefab.</param>
        private void getNewUFO (GameObject ufo) {
            Vector3 randomPosition;

            float positionInY = Random.Range(-stageLimitInY, stageLimitInY);

            randomPosition = new Vector3(-stageLimitInX, positionInY, 0);
            enemyManager.add(Instantiate(ufo, randomPosition, ufo.transform.rotation));
        }

        /// <summary>
        /// Filters the UFO creation only for the small ones.
        /// </summary>
        public void filter () {
            onAdvancedScore = true;
        }
    } 
}