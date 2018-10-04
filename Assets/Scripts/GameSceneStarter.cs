using SpaceChaos.Player.States;
using SpaceChaos.Stage.States;
using UnityEngine;

namespace SpaceChaos.Stage {
    /// <summary>
    /// Responsible for starting the entities machine states of the scene.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/Stage/GameSceneStarter")]
    public class GameSceneStarter : MonoBehaviour {
        /// <summary>Finite Machine State of Player.</summary>
        [SerializeField]
        private FMS playerFMS;
        /// <summary>Finite Machine State of Stage.</summary>
        [SerializeField]
        private FMS stageFMS;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            initializeFMS();
        }

        /// <summary>
        /// Initializes all the initial Finite Machine States.
        /// </summary>
        private void initializeFMS () {
            stageFMS.initialize(stageFMS.GetComponent<OnGameRunning>());
            playerFMS.initialize(playerFMS.GetComponent<Alive>());
        }
    }
}