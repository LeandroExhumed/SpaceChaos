using UnityEngine;

namespace SpaceChaos.Resources.InputSystem {
    /// <summary>
    /// Game input for joystick(XBOX 360/ONE).
    /// </summary>
    /// <seealso cref="SpaceChaos.Game.Resources.InputSystem.IGameInput" />
    public class JoystickInput : IGameInput {
        /// <summary>
        /// Gets the horizontal input value.
        /// </summary>
        /// <returns></returns>
        public float getHorizontalAxis () {
            return Input.GetAxis("J_Horizontal");
        }

        /// <summary>
        /// Gets the vertical input value.
        /// </summary>
        /// <returns></returns>
        public float getVerticalAxis () {
            return Input.GetAxis("J_Vertical");
        }

        /// <summary>
        /// Whether the shoting button is being pressed.
        /// </summary>
        /// <returns></returns>
        public bool isShoting () {
            return Input.GetButtonDown("Right Stick Click");
        }

        /// <summary>
        /// Whether the pause button is being pressed.
        /// </summary>
        /// <returns></returns>
        public bool isPausing () {
            return Input.GetButtonDown("Start Button");
        }
    } 
}