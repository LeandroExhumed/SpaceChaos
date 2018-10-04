using SpaceChaos.Constants;
using UnityEngine;

namespace SpaceChaos.Enemies {
    /// <summary>
    /// Damage system for the enemies.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.IDamageable" />
    [AddComponentMenu("SpaceChaos/Enemies/RandomShot")]
    public class Damage : MonoBehaviour, IDamageable {
        /// <summary>Amount of points that player will score by each destruction.</summary>
        [SerializeField]
        private int pointsToGive = 20;

        /// <summary>Event fired when this object is destroyed.</summary>
        public event System.Action onDestruction;
        /// <summary>Event fired when this action gives player points.</summary>
        public event System.Action<int> onScoring;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            onDestruction += () => GameObject.FindGameObjectWithTag(Tags.ENEMY_Manager).
                GetComponent<EnemyManager>().remove(gameObject);
            onScoring += GameObject.FindGameObjectWithTag(Tags.SCORE).GetComponent<Score>().addPoints;
        }

        /// <summary>
        /// Takes damage from some collision.
        /// </summary>
        public void takeDamage () {
            onDestruction();
            onScoring(pointsToGive);
        }

        /// <summary>
        /// Increases how many points this enemy worths.
        /// </summary>
        public void increaseValue () {
            pointsToGive *= 2;
        }
    } 
}