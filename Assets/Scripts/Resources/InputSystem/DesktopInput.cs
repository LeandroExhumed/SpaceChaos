using UnityEngine;

namespace SpaceChaos.Resources.InputSystem {
    /// <summary>
    /// Game input for desktop(keyboard).
    /// </summary>
    /// <seealso cref="SpaceChaos.Game.Resources.IGameInput" />
    public class DesktopInput : IGameInput {
        /// <summary>
        /// Gets the horizontal input value.
        /// </summary>
        /// <returns></returns>
        public float getHorizontalAxis () {
            return Input.GetAxis("Horizontal");
        }

        /// <summary>
        /// Gets the vertical input value.
        /// </summary>
        /// <returns></returns>
        public float getVerticalAxis () {
            return Input.GetAxis("Vertical");
        }

        /// <summary>
        /// Whether the shoting button is being pressed.
        /// </summary>
        /// <returns></returns>
        public bool isShoting () {
            return Input.GetKeyDown(KeyCode.Space);
        }

        /// <summary>
        /// Whether the pause button is being pressed.
        /// </summary>
        /// <returns></returns>
        public bool isPausing () {
            return Input.GetKeyDown(KeyCode.Escape);
        }
    } 
}