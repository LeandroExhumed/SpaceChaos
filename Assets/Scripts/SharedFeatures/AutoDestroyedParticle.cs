using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceChaos.SharedFeatures {
    /// <summary>
    /// Action of destroy this particle after its effect is over.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("SpaceChaos/SharedFeatures/AutoDestroyedParticle")]
    public class AutoDestroyedParticle : MonoBehaviour {
        private ParticleSystem c_particleSystem;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            c_particleSystem = GetComponent<ParticleSystem>();
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void Update () {
            if (!c_particleSystem.IsAlive()) {
                Destroy(gameObject);
            }
        }
    } 
}