using SpaceChaos.Resources;
using SpaceChaos.Resources.InputSystem;
using UnityEngine;

namespace SpaceChaos.Stage.States {
    /// <summary>
    /// State where the gameplay occurs.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.IState" />
    [AddComponentMenu("SpaceChaos/Stage/States/OnGameRunning")]
    public class OnGameRunning : MonoBehaviour, IState {
        /// <summary>Counter for respawn.</summary>
        private float timer = 0;
        /// <summary>Time in seconds to check whether add a UFO in game.</summary>
        private float secondsToCheckProbability = 10;

        /// <summary>Responsible for spawning the asteroids in match.</summary>
        [SerializeField]
        private AsteroidSpawner asteroidSpawner;
        /// <summary>Responsible for spawning the UFOs in match.</summary>
        [SerializeField]
        UFOSpawner ufoSpawner;
        /// <summary>Responsible for spawning the asteroids in match.</summary>
        [SerializeField]
        StageData stageManager;

        [SerializeField]
        private InputProcessor input;
        /// <summary>Resource of pausing/unpausing the game.</summary>
        [SerializeField]
        private Pause pause;

        /// <summary>
        /// Starts the state.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void onEnter (params object[] parameters) {
            for (int i = 0; i < stageManager.asteroidsPerStage; i++) {
                asteroidSpawner.createAsteroid();
            }
        }

        /// <summary>
        /// Executes the state action.
        /// </summary>
        public void onUpdate () {
            if (input.gameInput.isPausing()) {
                pause.execute();
            }

            if (timer >= secondsToCheckProbability) {
                timer = 0;

                float probability = Random.value;
                if (probability >= 0.5f) {
                    ufoSpawner.createUFO();
                }
            }

            timer += Time.deltaTime;
        }

        /// <summary>
        /// Handles what is needed before leaving this state.
        /// </summary>
        public void onExit () {

        }
    } 
}