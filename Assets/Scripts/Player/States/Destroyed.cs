using SpaceChaos.Constants;
using SpaceChaos.AudioSystem;
using System.Collections;
using UnityEngine;

namespace SpaceChaos.Player.States {
    /// <summary>
    /// State where the player ship is destroyed.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.IState" />
    [AddComponentMenu("SpaceChaos/Player/States/Destroyed")]
    public class Destroyed : MonoBehaviour, IState {
        /// <summary>Counter for respawn.</summary>
        private float timer = 0;
        /// <summary>Time in seconds to respawn the player ship.</summary>
        private float secondsToRespawn = 4f;

        /// <summary>Life system for the player.</summary>
        [SerializeField]
        private Life life;
        /// <summary>Event fired when the ship is respawned.</summary>
		public event System.Action onShipRespawn;
        /// <summary>Event fired when player loses all his lifes.</summary>
		public event System.Action onGameOverMessage;

        /// <summary>Game audio manager.</summary>
        [SerializeField]
        private AudioManager audioManager;

        /// <summary>Cached RigidBody component.</summary>
        private Rigidbody c_rigidbody;
        /// <summary>Cached Collider component.</summary>
        private Collider c_boxCollider;
        /// <summary>Explosion effect.</summary>
        [SerializeField]
        private GameObject explosion;

        /// <summary>Mesh parts of the spaceship.</summary>
        [SerializeField]
        private GameObject[] meshes;

        [SerializeField]
        private GameObject stageManager;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            c_rigidbody = GetComponent<Rigidbody>();
            c_boxCollider = GetComponent<BoxCollider>();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            onShipRespawn += () => GetComponent<Respawning>().execute();
            onShipRespawn += () => GetComponent<FMS>().changeToState(GetComponent<Alive>());
            onGameOverMessage += () => stageManager.GetComponent<FMS>().changeToState(
                stageManager.GetComponent<GameOver>());
        }

        /// <summary>
        /// Starts the state.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void onEnter (params object[] parameters) {
            life.loseLife();

            c_rigidbody.velocity = Vector3.zero;
            c_boxCollider.enabled = false;
            for (int i = 0; i < meshes.Length; i++) {
                meshes[i].SetActive(false);
            }

            explosion.SetActive(true);
            audioManager.playSound(AudioManager.SoundType.Explosion);
        }

        /// <summary>
        /// Executes the state action.
        /// </summary>
        public void onUpdate () {
            if (timer >= secondsToRespawn) {
                timer = 0;

                if (life.currentLife == 0) {
                    onGameOverMessage();
                } else {
                    onShipRespawn();
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