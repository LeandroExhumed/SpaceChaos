using SpaceChaos.AudioSystem;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceChaos {
    /// <summary>
    /// Life system that allows player still playing after losing.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/Life")]
    public class Life : MonoBehaviour {
        private int _currentLife = 3;
        /// <summary>Current Life number.</summary>
        public int currentLife {
            get { return _currentLife; }
            private set {
                _currentLife = value;

                lifeLabel.text = string.Concat("x ", currentLife.ToString());
            }
        }

        /// <summary>The initial value of life.</summary>
        [SerializeField]
        private int initialLife = 3;
        /// <summary>The limit amount that player can has.</summary>
        private int maximumAmount = 99990;

        /// <summary>Label that shows the player life amount.</summary>
        [SerializeField]
        private Text lifeLabel;

        /// <summary>Score system related to the points made in game.</summary>
        [SerializeField]
        private Score score;

        /// <summary>Game audio manager.</summary>
        [SerializeField]
        private AudioManager audioManager;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            currentLife = initialLife;
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            score.onRewardPoints += gainOneLife;
        }

        /// <summary>
        /// Gives player 1 more life.
        /// </summary>
        public void gainOneLife () {
            if (currentLife < maximumAmount) {
                currentLife++;
                audioManager.playSound(AudioManager.SoundType.LifeGain);
            }
        }

        /// <summary>
        /// Increase the player life by 1.
        /// </summary>
        public void loseLife () {
            currentLife--;
        }
    }
}