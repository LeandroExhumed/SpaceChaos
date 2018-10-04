using UnityEngine;

namespace SpaceChaos.SharedFeatures {
    /// <summary>
    /// Collision between this object and others that are allowed to.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/SharedFeatures/Collision")]
    public class Collision : MonoBehaviour {
        /// <summary>Layers that this object is allowed to trigger.</summary>
        [SerializeField]
        private LayerMask layersToCollide;

        /// <summary>
        /// Unity callback that fires when a trigger collision occurs.
        /// </summary>
        /// <param name="collision">The collision.</param>
        protected virtual void OnTriggerEnter (Collider collision) {
            if (CompareLayer(collision)) {
                collision.GetComponent<IDamageable>().takeDamage();
            }
        }

        /// <summary>
        /// Compares the layer of the collided object with the layers allowed o be collided.
        /// </summary>
        /// <param name="collision">The collision.</param>
        /// <returns></returns>
        protected bool CompareLayer (Collider collision) {
            return 1 << collision.gameObject.layer == (layersToCollide & 1 << collision.gameObject.layer);
        }
    } 
}