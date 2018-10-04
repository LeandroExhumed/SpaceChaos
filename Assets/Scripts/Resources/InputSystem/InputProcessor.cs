using UnityEngine;

namespace SpaceChaos.Resources.InputSystem {
    /// <summary>
    /// Core of the game input.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/Resources/InputProcessor")]
    public class InputProcessor : MonoBehaviour {
        /// <summary>Chosen input for playing the game.</summary>
        [SerializeField]
        private InputType inputType;
        /// <summary>Appropriate input based on the input type option.</summary>
        public IGameInput gameInput { get; set; }

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            setControll();
        }

        /// <summary>
        /// Configures the game input based on Inspector choose.
        /// </summary>
        private void setControll () {
            switch (inputType) {
                case InputType.desktop:
                    gameInput = new DesktopInput();
                    break;
                case InputType.joystick:
                    gameInput = new JoystickInput();
                    break;
            }
        }
    } 
}