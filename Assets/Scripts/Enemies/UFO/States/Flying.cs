using UnityEngine;

namespace SpaceChaos.UFO.States {
    /// <summary>
    /// State where the UFO is flying through its route.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.IState" />
    [AddComponentMenu("SpaceChaos/UFO/States/Flying")]
    public class Flying : MonoBehaviour, IState {
        /// <summary>Hability to move through the space using a random route.</summary>
        private ICommand randomRoute;
        /// <summary>Hability to execute shots randomly around the space.</summary>
        private AutoShoting randomShot;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            randomRoute = GetComponent<RandomRoute>();
            randomShot = GetComponent<AutoShoting>();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            GetComponent<FMS>().initialize(this);
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
            randomRoute.execute();
            randomShot.execute();
        }

        /// <summary>
        /// Handles what is needed before leaving this state.
        /// </summary>
        public void onExit () {
            
        }
    }
}