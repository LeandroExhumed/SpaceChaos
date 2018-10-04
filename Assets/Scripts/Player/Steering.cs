using UnityEngine;

namespace SpaceChaos.Player {
    /// <summary>
    /// Hability to steer the ship by rotating it.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.ICommand" />
    [AddComponentMenu("SpaceChaos/Player/Steering")]
    public class Steering : MonoBehaviour, ICommand {
        /// <summary>Speed of the rotation when steering.</summary>
        private float speed = 300f;

        /// <summary>
        /// Rotates the ship to the requested direction.
        /// </summary>
        /// <param name="parameters">The direction to rotate.</param>
        public void execute (params object[] parameters) {
            float direction = (float)parameters[0];

            transform.Rotate(0, 0, -direction * speed * Time.deltaTime);
        }
    } 
}