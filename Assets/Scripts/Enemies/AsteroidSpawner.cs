using SpaceChaos.Stage;
using UnityEngine;

namespace SpaceChaos {
    /// <summary>
    /// Responsible for spawning the asteroids in match.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/Enemies/AsteroidSpawner")]
    public class AsteroidSpawner : MonoBehaviour {
        /// <summary>Limit position of game stage on X axis.</summary>
        private float stageLimitInX = 9;
        /// <summary>Limit position of game stage on Y axis.</summary>
        private float stageLimitInY = 2.5f;
        /// <summary>Minimum distance that the asteroid has to have from the screen center.</summary>
        private float minimumDistance = 4;

        /// <summary>The Asteroid prefab.</summary>
        [SerializeField]
        private GameObject asteroid;

        /// <summary>All important data related to the stage.</summary>
        [SerializeField]
        private StageData stageData;
        /// <summary>The system responsible for checking all enemies of the stage..</summary>
        [SerializeField]
        private EnemyManager enemyManager;

        /// <summary>Player spaceship used as reference to positionate the asteroids.</summary>
        [SerializeField]
        private Transform player;

        /// <summary>
        /// Creates a new asteroid with the right configs.
        /// </summary>
        public void createAsteroid () {
            Vector3 randomPosition;

            do {
                float positionInX = Random.Range(-stageLimitInX, stageLimitInX);
                float positionInY = Random.Range(-stageLimitInY, stageLimitInY);

                randomPosition = new Vector3(positionInX, positionInY, 0);
            } while ((player.position - randomPosition).sqrMagnitude < minimumDistance);

            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            enemyManager.add(Instantiate(asteroid, randomPosition, randomRotation));
        }
    } 
}