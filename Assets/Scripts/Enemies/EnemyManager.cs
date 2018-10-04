using System.Collections.Generic;
using UnityEngine;

namespace SpaceChaos {
    /// <summary>
    /// The system responsible for checking all enemies of the stage. 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/Enemies/EnemyManager")]
    public class EnemyManager : MonoBehaviour {
        /// <summary>List containing all the asteroids and UFOs of the stage.</summary>
        private List<GameObject> enemies = new List<GameObject>();
        /// <summary>List of the instantiated enemies to destroy them on stage clear.</summary>
        private List<GameObject> cache = new List<GameObject>();

        /// <summary>Event fired when all enemies of the stage is destroyed.</summary>
		public event System.Action onAsteroidsClear;

        /// <summary>
        /// Adds a new enemy to the game.
        /// </summary>
        /// <param name="enemy">The enemy.</param>
        public void add (GameObject enemy) {
            enemies.Add(enemy);
            cache.Add(enemy);
        }

        /// <summary>
        /// Removes the specified enemy of the game.
        /// </summary>
        /// <param name="enemy">The enemy.</param>
        public void remove (GameObject enemy) {
            enemies.Remove(enemy);
            enemy.SetActive(false);

            checkEnemiesSituation();
        }

        /// <summary>
        /// Verifies if all the enemies of the stage is over.
        /// </summary>
        private void checkEnemiesSituation () {
            if (enemies.Count == 0) {
                for (int i = 0; i < cache.Count; i++) {
                    Destroy(cache[i]);
                }

                onAsteroidsClear();
            }
        }
    } 
}