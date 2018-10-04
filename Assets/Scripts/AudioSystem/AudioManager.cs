using System.Collections.Generic;
using UnityEngine;

namespace SpaceChaos.AudioSystem {
    /// <summary>
    /// Manager/Pool of the SFX/Music system.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/AudioSystem/AudioManager")]
    public class AudioManager : MonoBehaviour {
        /// <summary>Default volume of the background music.</summary>
        [SerializeField]
        private float initialMusicVolume = 1;
        /// <summary>Whether the current scene has background music.</summary>
        [SerializeField]
        private bool hasBackgroundMusic;
        /// <summary>Prefab of the music AudioSource.</summary>
        [SerializeField]
        private AudioSource musicSourcePrefab;

        /// <summary>How many instances will fill the pool.</summary>
        [SerializeField]
        public int poolSize = 2;

        /// <summary>All the different types of sound on game.</summary>
        public enum SoundType {
            LaserShot,
            Explosion,
            LifeGain,
            ButtonPress
        }

        /// <summary>List with all the type of sound of the game.</summary>
        public List<SoundType> soundTypeList;
        /// <summary>All the respective audios to their type.</summary>
        public List<AudioClip> audioClipList;

        /// <summary>Queue containing all the AudioSource pool instances.</summary>
        private Queue<AudioSource> poolQueue = new Queue<AudioSource>();


        /// <summary>AudioSource responsible for the background music.</summary>
        private AudioSource musicSource;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            prepareBackgroundMusic();
            createPool();
        }

        /// <summary>
        /// Prepare the music source and its default attributes.
        /// </summary>
        public void prepareBackgroundMusic () {
            if (hasBackgroundMusic) {
                musicSource = Instantiate(musicSourcePrefab) as AudioSource;
                musicSource.transform.SetParent(transform);
                resetMusicVolume();
            }
        }

        /// <summary>
        /// Plays a sound using a poolable AudioSource.
        /// </summary>
        /// <param name="soundType">The requested sound type</param>
        public void playSound (SoundType soundType) {
            AudioSource objectToReuse = reuse();
            objectToReuse.PlayOneShot(GetAudioClip(soundType));
        }

        /// <summary>
        /// Sets the music source volume.
        /// </summary>
        /// <param name="volume">The volume.</param>
        public void setMusicVolume (float volume) {
            if (musicSource != null) {
                musicSource.volume = volume;
            }
        }

        /// <summary>
        /// Resets the music source volume to its initial value.
        /// </summary>
        public void resetMusicVolume () {
            setMusicVolume(initialMusicVolume);
        }

        /// <summary>
        /// Creates a new pool of AudioSource object to reuse.
        /// </summary>
        private void createPool () {
            GameObject objectContainer = new GameObject("PoolableAudioSources");
            for (int i = 0; i < poolSize; i++) {
                GameObject poolableObject = new GameObject("AudioSource");
                AudioSource newObject = poolableObject.AddComponent<AudioSource>();
                newObject.transform.SetParent(objectContainer.transform);
                newObject.gameObject.SetActive(false);
                // Depois de instanciar ele adiciona dentro da fila.
                poolQueue.Enqueue(newObject);
            }
        }

        /// <summary>
        /// Returns the audio clip for the requested sound type. If there are
        /// more that one audio clips, we get a random one 
        /// </summary>
        /// <param name="soundType">The requested sound type</param>
        /// <returns>The requsted audio clip</returns>
        private AudioClip GetAudioClip (SoundType soundType) {
            int audioIndex = (int)soundType;

            return audioClipList[audioIndex];
        }

        /// <summary>
        /// Reuses an AudioSource from the queue.
        /// </summary>
        /// <returns></returns>
        private AudioSource reuse () {
            AudioSource objectToReuse = poolQueue.Dequeue();
            poolQueue.Enqueue(objectToReuse);

            objectToReuse.gameObject.SetActive(true);

            return objectToReuse;
        }
    } 
}