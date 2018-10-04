using UnityEngine;

namespace SpaceChaos.Player {
    /// <summary>
    /// Hability to thrust the ship.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.ICommand" />
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("SpaceChaos/Player/Thrusting")]
    public class Thrusting : MonoBehaviour, ICommand {
        /// <summary>The force applied to thrust the ship.</summary>
        [SerializeField]
        private float force = 5f;
        /// <summary>The minimal value of the velocity to turn on the thrusters.</summary>
        private float thrusterMinVelocity = 0.3f;

        /// <summary>Fire particles from the thrusters.</summary>
        [SerializeField]
        private GameObject thrusterFire;

        /// <summary>Cached RigidBody component.</summary>
        private Rigidbody c_rigidbody;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            c_rigidbody = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Thrust the player ship to its forward.
        /// </summary>
        /// <param name="parameters">The input value.</param>
        public void execute (params object[] parameters) {
            float input = (float)parameters[0];

            if (input > 0) {
                c_rigidbody.AddForce(transform.up * force * input);
            }

            checkThrusterActivation();
        }

        /// <summary>
        /// Checks whether the thrusters has to be activated/deactivated.
        /// </summary>
        private void checkThrusterActivation () {
            if (c_rigidbody.velocity.magnitude >= thrusterMinVelocity) {
                thrusterFire.SetActive(true);
            } else {
                thrusterFire.SetActive(false);
            }
        }
    } 
}