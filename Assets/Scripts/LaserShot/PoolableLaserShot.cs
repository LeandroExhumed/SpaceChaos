using SpaceChaos.Utils.PoolingSystem;
using SpaceChaos.SharedFeatures;
using UnityEngine;

namespace SpaceChaos.LaserShot {
    /// <summary>
    /// Prefab of Laser shot to be instantiated and pooled.
    /// </summary>
    /// <seealso cref="SpaceChaos.Utils.PoolingSystem.PoolableObject" />
    [AddComponentMenu("SpaceChaos/LaserShot/PoolableLaserShot")]
    public class PoolableLaserShot : PoolableObject {
        /// <summary>Command for making the laser shot drift through space.</summary>
        private ICommand drifting;

        /// <summary>Cached RigidBody component.</summary>
        private Rigidbody c_rigidbody;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        protected void Awake () {
            drifting = GetComponent<Drifting>();
            c_rigidbody = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Reset some aspects of the object when reused, acting as a Start().
        /// </summary>
        public override void OnObjectReuse () {
            c_rigidbody.velocity = Vector3.zero;
            drifting.execute();
        }
    }
}