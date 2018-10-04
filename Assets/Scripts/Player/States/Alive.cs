using SpaceChaos.SharedFeatures;
using SpaceChaos.Resources.InputSystem;
using UnityEngine;

namespace SpaceChaos.Player.States {
    /// <summary>
    /// Normal state of the player ship.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.IState" />
    [AddComponentMenu("SpaceChaos/Player/States/Alive")]
    public class Alive : MonoBehaviour, IState {
        [SerializeField]
        private InputProcessor input;

        /// <summary>Steering of the player ship to left and right.</summary>
        private ICommand steering;
        /// <summary>Thrusting of the player ship.</summary>
        private ICommand thrusting;
        /// <summary>Hability to shot.</summary>
        private ICommand shoting;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            steering = GetComponent<Steering>();
            thrusting = GetComponent<Thrusting>();
            shoting = GetComponent<Shoting>();
        }

        /// <summary>
        /// Starts the state.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void onEnter (params object[] parameters) {
            
        }

        /// <summary>
        /// Executes the state action.
        /// </summary>
        public void onUpdate () {
            steering.execute(input.gameInput.getHorizontalAxis());

            thrusting.execute(input.gameInput.getVerticalAxis());

            if (input.gameInput.isShoting()) {
                shoting.execute();
            }
        }

        /// <summary>
        /// Handles what is needed before leaving this state.
        /// </summary>
        public void onExit () {

        }
    } 
}