using SpaceChaos.Constants;
using SpaceChaos.Utils.PoolingSystem;
using UnityEngine;

namespace SpaceChaos.LaserShot {
    /// <summary>
    /// Special collision treatment for shots.
    /// </summary>
    /// <seealso cref="SpaceChaos.SharedFeatures.Collision" />
    [AddComponentMenu("SpaceChaos/LaserShot/ShotCollision")]
    public class ShotCollision : SharedFeatures.Collision {

        /// <summary>
        /// Unity callback that fires when a trigger collision occurs.
        /// </summary>
        /// <param name="collision">The collision.</param>
        protected override void OnTriggerEnter (Collider collision) {
            if (CompareLayer(collision)) {
                    collision.GetComponent<IDamageable>().takeDamage();
                    GetComponent<PoolableObject>().destroy();
            }

            if (collision.CompareTag(Tags.SPACE_WIDTH_LIMIT) || collision.CompareTag(Tags.SPACE_HEIGHT_LIMIT)) {
                GetComponent<PoolableObject>().destroy();
            }
        }
    }
}