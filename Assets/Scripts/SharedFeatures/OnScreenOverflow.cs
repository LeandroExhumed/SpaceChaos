using SpaceChaos.Constants;
using UnityEngine;

namespace SpaceChaos.SharedFeatures {
    /// <summary>
    /// Handler of the ship when it surpass the screen limits.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/SharedFeatures/OnScreenOverflow")]
    public class OnScreenOverflow : MonoBehaviour {
        /// <summary>Amount of space to add to position to avoid enter collision loops.</summary>
        private float compensation = 0.5f;

        /// <summary>Cached RigidBody component.</summary>
        private Rigidbody c_rigidbody;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            c_rigidbody = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Unity callback that fires when a trigger collision occurs.
        /// </summary>
        /// <param name="other">The other.</param>
        private void OnTriggerEnter (Collider other) {
            if (other.CompareTag(Tags.SPACE_WIDTH_LIMIT)) {
                Vector3 newPosition = transform.position;
                float forward = c_rigidbody.velocity.normalized.x * compensation;
                newPosition.x = -newPosition.x + forward;

                transform.position = newPosition;
            }

            if (other.CompareTag(Tags.SPACE_HEIGHT_LIMIT)) {
                Vector3 newPosition = transform.position;
                float forward = c_rigidbody.velocity.normalized.y * compensation;
                newPosition.y = -newPosition.y + forward;

                transform.position = newPosition;
            }
        }
    } 
}