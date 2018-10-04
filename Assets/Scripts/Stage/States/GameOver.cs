using UnityEngine;

namespace SpaceChaos {
    /// <summary>
    /// State where the match is over because of player death.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.IState" />
    public class GameOver : MonoBehaviour, IState {
        /// <summary>Panel shown after player dies showing its score.</summary>
        [SerializeField]
        private GameObject gameOverPanel;

        /// <summary>
        /// Starts the state.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void onEnter (params object[] parameters) {
            gameOverPanel.SetActive(true);
        }

        /// <summary>
        /// Executes the state action.
        /// </summary>
        public void onUpdate () {

        }

        /// <summary>
        /// Handles what is needed before leaving this state.
        /// </summary>
        public void onExit () {

        }
    } 
}