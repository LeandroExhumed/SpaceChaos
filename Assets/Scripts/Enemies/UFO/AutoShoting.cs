using SpaceChaos.SharedFeatures;
using UnityEngine;

namespace SpaceChaos.UFO {
    /// <summary>
    /// Hability of the AI to perform shots.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public abstract class AutoShoting : MonoBehaviour, ICommand {
        /// <summary>Timer for the time to shot.</summary>
        private float timer = 0;
        /// <summary>Speed of the gun rotation.</summary>
        [SerializeField]
        protected float speed = 8;
        /// <summary>How often in minutes a new shot will be given.</summary>
        [SerializeField]
        private float shotingRate = 1;

        /// <summary>Guns where the laser shots will be shot..</summary>
        [SerializeField]
        protected Transform[] guns;

        /// <summary>Hability to shooting laser.</summary>
        private Shoting shoting;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        protected virtual void Awake () {
            shoting = GetComponent<Shoting>();
        }

        /// <summary>
        /// Executes all the shoting process.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void execute (params object[] parameters) {
            calculateTimer();
            processRotation();
        }

        /// <summary>
        /// Executes the guns rotation process.
        /// </summary>
        protected abstract void processRotation ();

        /// <summary>
        /// Calculates the timer to a new shot.
        /// </summary>
        private void calculateTimer () {
            if (timer >= shotingRate) {
                timer = 0;
                shot();
            }

            timer += Time.deltaTime;
        }

        /// <summary>
        /// Executes the shot.
        /// </summary>
        protected virtual void shot () {
            shoting.execute();
        }
    }
}