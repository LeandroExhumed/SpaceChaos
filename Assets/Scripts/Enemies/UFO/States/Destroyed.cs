using SpaceChaos.Constants;
using SpaceChaos.AudioSystem;
using SpaceChaos.Enemies;
using UnityEngine;

namespace SpaceChaos.UFO.States {
    /// <summary>
    /// State where the player ship is destroyed.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.IState" />
    [AddComponentMenu("SpaceChaos/UFO/States/RandomShot")]
    public class Destroyed : MonoBehaviour, IState {
        /// <summary>Counter for the ship exclusion.</summary>
        private float timer = 0;
        /// <summary>Time in seconds to removes the spaceship from game.</summary>
        private float secondsToDisappear = 4f;

        /// <summary>Mesh of the ship.</summary>
        [SerializeField]
        private GameObject mesh;
        /// <summary>Explosion effect prefab.</summary>
        [SerializeField]
        private GameObject explosion;

        /// <summary>Game audio manager.</summary>
        private AudioManager audioManager;

        /// <summary>Cached Collider component.</summary>
        private Collider c_boxCollider;

        /// <summary>Event fired when is time to be removed of stage.</summary>
        public event System.Action onDisappear;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            c_boxCollider = GetComponent<BoxCollider>();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            audioManager = GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>();
            onDisappear += () => GameObject.FindGameObjectWithTag(Tags.ENEMY_Manager).
                GetComponent<EnemyManager>().remove(gameObject);
            GetComponent<Damage>().onDestruction += () => GetComponent<FMS>().changeToState(this);
        }

        /// <summary>
        /// Starts the state.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void onEnter (params object[] parameters) {
            c_boxCollider.enabled = false;
            mesh.SetActive(false);

            Destroy(Instantiate(explosion, transform.position, explosion.transform.rotation), 3);

            audioManager.playSound(AudioManager.SoundType.Explosion);
        }

        /// <summary>
        /// Executes the state action.
        /// </summary>
        public void onUpdate () {
            if (timer >= secondsToDisappear) {
                timer = 0;

                onDisappear();
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