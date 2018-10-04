using UnityEngine;

namespace SpaceChaos.SharedFeatures {
    /// <summary>
    /// Hability of drift through the space.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.ICommand" />
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("SpaceChaos/SharedFeatures/Drifting")]
    public class Drifting : MonoBehaviour, ICommand {
        /// <summary>Speed of the object drifting through space.</summary>
        [SerializeField]
        private float speed = 50f;

        /// <summary>Cached RigidBody component.</summary>
        private Rigidbody c_rigidbody;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            c_rigidbody = GetComponent<Rigidbody>();
            execute();
        }

        /// <summary>
        /// Applies a force to the object causing it a movement.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void execute (params object[] parameters) {
            c_rigidbody.AddForce(transform.up * speed);
        }

        /// <summary>
        /// Increases the speed of the drifting movement.
        /// </summary>
        public void increaseSpeed () {
            speed *= 1.5f;
        }
    }
}