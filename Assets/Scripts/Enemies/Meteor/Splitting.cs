using SpaceChaos.Constants;
using SpaceChaos.AudioSystem;
using SpaceChaos.SharedFeatures;
using SpaceChaos.Enemies;
using UnityEngine;

namespace SpaceChaos.Asteroid {
    /// <summary>
    /// Hability to break into smaller pieces after being destroyed.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.ICommand" />
    [AddComponentMenu("SpaceChaos/Asteroid/Splitting")]
    public class Splitting : MonoBehaviour, ICommand {
        /// <summary>How many times the asteroid was broken.</summary>
        [SerializeField]
        private int timesBroken = 0;
        /// <summary>Maximum number of times that the asteroid can be broken.</summary>
        [SerializeField]
        private int maximumPieces = 2;

        /// <summary>The system responsible for checking all enemies of the stage.</summary>
        public EnemyManager enemyManager;

        /// <summary>Game audio manager.</summary>
        private AudioManager audioManager;

        /// <summary>Event fired when all enemies of the stage is destroyed.</summary>
		public event System.Action<GameObject> onNewPiece;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            enemyManager = GameObject.FindGameObjectWithTag(Tags.ENEMY_Manager).GetComponent<EnemyManager>();
            onNewPiece += enemyManager.add;

            audioManager = GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>();
            GetComponent<Damage>().onDestruction += () => execute();
        }

        /// <summary>
        /// Generates more pieces from the asteroid when the destroyed.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void execute (params object[] parameters) {
            audioManager.playSound(AudioManager.SoundType.Explosion);

            if (timesBroken < 2) {
                Quaternion randomRotation;

                for (int i = 0; i < maximumPieces; i++) {
                    randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                    GameObject obj = Instantiate(gameObject, transform.localPosition, randomRotation);
                    obj.GetComponent<Splitting>().decrease();

                    onNewPiece(obj);
                }
            }
        }

        /// <summary>
        /// Decreases this asteroid to a smaller piece.
        /// </summary>
        private void decrease () {
            timesBroken++;
            gameObject.SetActive(true);
            transform.localScale /= 2;
            GetComponent<Drifting>().increaseSpeed();
            GetComponent<Damage>().increaseValue();
        }
    }
}