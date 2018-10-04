using UnityEngine;

namespace SpaceChaos.Player {
    /// <summary>
    /// Hability of player reviving after being destroyed.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.ICommand" />
    [AddComponentMenu("SpaceChaos/Player/Respawning")]
    public class Respawning : MonoBehaviour, ICommand {
        /// <summary>Explosion effect.</summary>
        [SerializeField]
        private GameObject explosion;
        /// <summary>Effect of the player ship blinking while it's invencible after reviving.</summary>
        private UntouchableBlinking respawnBlinking;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            respawnBlinking = GetComponent<UntouchableBlinking>();
        }

        /// <summary>
        /// Respawn the ship on its original position.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void execute (params object[] parameters) {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;

            explosion.SetActive(false);
            respawnBlinking.startBlinking();
        }
    }
}