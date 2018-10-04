using SpaceChaos.Player.States;
using UnityEngine;

namespace SpaceChaos.Player {
    /// <summary>
    /// Damage system for the player ship.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.IDamageable" />
    [AddComponentMenu("SpaceChaos/Player/damage")]
    public class Damage : MonoBehaviour, IDamageable {
        /// <summary>Event fired when this object is destroyed.</summary>
        public event System.Action onDestruction;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            onDestruction += () => GetComponent<FMS>().changeToState(GetComponent<Destroyed>());
        }

        /// <summary>
        /// Takes the damage from collision or shot.
        /// </summary>
        public void takeDamage () {
            onDestruction();
        }
    } 
}