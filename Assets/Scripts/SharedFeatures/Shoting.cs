using SpaceChaos.Constants;
using SpaceChaos.AudioSystem;
using SpaceChaos.Utils.PoolingSystem;
using UnityEngine;

namespace SpaceChaos.SharedFeatures {
    /// <summary>
    /// Hability to shoting.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.ICommand" />
    [AddComponentMenu("SpaceChaos/SharedFeatures/Shoting")]
    public class Shoting : MonoBehaviour, ICommand {
        /// <summary>Guns where the laser shots will be shot.</summary>
        [SerializeField]
        private Transform[] guns;

        /// <summary>Number of shot instances that will be stored on pool.</summary>
        [SerializeField]
        private int poolSize = 20;
        /// <summary>Pool containing the laser shot instances.</summary>
        private Pool[] pool;
        /// <summary>Laser shot prefab.</summary>
        [SerializeField]
        private PoolableObject laserShot;

        /// <summary>Game audio manager.</summary>
        private AudioManager audioManager;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            pool = new Pool[guns.Length];
            for (int i = 0; i < pool.Length; i++) {
                pool[i] = new Pool(laserShot, poolSize);
            }
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            if (!audioManager) {
                audioManager = GameObject.FindGameObjectWithTag(Tags.AUDIO_MANAGER).GetComponent<AudioManager>();
            }
        }

        /// <summary>
        /// Shots a laser from the canon.
        /// </summary>
        public void execute (params object[] parameters) {
            for (int i = 0; i < guns.Length; i++) {
                pool[i].reuse(guns[i].position, guns[i].rotation);
            }
            
            audioManager.playSound(AudioManager.SoundType.LaserShot);
        }
    } 
}