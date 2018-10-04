using UnityEngine;

namespace SpaceChaos {
    /// <summary>
    /// Finite machine state for objects that represent some entity in game.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/FMS")]
    public class FMS : MonoBehaviour {
        /// <summary>Whether the state to run has initialized.</summary>
        private bool isInitialized = false;
        /// <summary>Current state running.</summary>
        private IState state;

        /// <summary>
        /// Default state of this FMS.
        /// </summary>
        /// <param name="initialState">The initial state.</param>
        public void initialize (IState initialState) {
            changeToState(initialState);
            isInitialized = true;
        } 

        /// <summary>
        /// Changes to state.
        /// </summary>
        /// <param name="newState">The state to start.</param>
        /// <param name="parameters">Optional parameters.</param>
        public void changeToState (IState newState, params object[] parameters) {
            if (isInitialized) {
                state.onExit();
            }

            state = newState;
            state.onEnter(parameters);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        private void Update () {
            if (isInitialized) {
                state.onUpdate();
            }
        }
    }
}