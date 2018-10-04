using SpaceChaos.Stage.States;
using UnityEngine;

namespace SpaceChaos {
    /// <summary>
    /// State where the player has beat the stage and waits to the next stage.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.IState" />
    [AddComponentMenu("SpaceChaos/Stage/States/OnStageClear")]
    public class OnStageClear : MonoBehaviour, IState {
        /// <summary>Timer for the next stage.</summary>
        private float timer = 0;
        /// <summary>Time in seconds to start the new stage.</summary>
        private float timeToNextStage = 3f;

        /// <summary>A message that shows that player cleared the stage.</summary>
        [SerializeField]
        private GameObject successMessage;

        /// <summary>The system responsible for checking all enemies of the stage..</summary>
        [SerializeField]
        private EnemyManager enemyManager;

        /// <summary>Finite Machine State of Stage.</summary>
        private FMS fms;
        /// <summary>.</summary>
        private IState onGameRunning;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            fms = GetComponent<FMS>();
            onGameRunning = GetComponent<OnGameRunning>();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            enemyManager.onAsteroidsClear += () => fms.changeToState(this);
        }

        /// <summary>
        /// Starts the state.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void onEnter (params object[] parameters) {
            successMessage.SetActive(true);
        }

        /// <summary>
        /// Executes the state action.
        /// </summary>
        public void onUpdate () {
            if (timer >= timeToNextStage) {
                timer = 0;
                fms.changeToState(onGameRunning);
            }

            timer += Time.deltaTime;
        }

        /// <summary>
        /// Handles what is needed before leaving this state.
        /// </summary>
        public void onExit () {
            successMessage.SetActive(false);
        }
    } 
}