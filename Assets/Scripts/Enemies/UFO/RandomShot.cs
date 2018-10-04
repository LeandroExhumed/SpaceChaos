using UnityEngine;

namespace SpaceChaos.UFO {
    /// <summary>
    /// Hability to execute shots randomly around the space.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/UFO/RandomShot")]
    public class RandomShot : AutoShoting {
        /// <summary>The direction that the guns will rotate.</summary>
        private float gunsDirection;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        protected override void Awake () {
            base.Awake();
            gunsDirection = getNewDirection();
        }

        /// <summary>
        /// Executes the guns rotation process.
        /// </summary>
        protected override void processRotation () {
            for (int i = 0; i < guns.Length; i++) {
                guns[i].Rotate(0, 0, -gunsDirection * speed * Time.deltaTime);
            }
        }

        /// <summary>
        /// Executes the shot.
        /// </summary>
        protected override void shot () {
            base.shot();
            gunsDirection = getNewDirection();
        }

        /// <summary>
        /// Returns a new random direction to rotate to.
        /// </summary>
        /// <returns></returns>
        private float getNewDirection () {
            return Random.Range(0, 360);
        }
    } 
}