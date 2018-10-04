using SpaceChaos.AudioSystem;
using UnityEngine;

namespace SpaceChaos.Resources {
    /// <summary>
    /// Resource of pausing/unpausing the game.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.Core.Interfaces.ICommand" />
    [AddComponentMenu("SpaceChaos/Resources/Pause")]
    public class Pause : MonoBehaviour, ICommand {
        /// <summary>Lower volume for music when pause menu is on.</summary>
		private float pauseMusicVolume = 0.2f;
        /// <summary>Whether the game is paused or not.</summary>
        private bool isPaused = false;

        /// <summary>The pause menu to be opened/closed.</summary>
        [SerializeField]
        private GameObject startMenu;

        /// <summary>Game audio manager.</summary>
        [SerializeField]
        private AudioManager audioManager;

        /// <summary>
        /// Pauses the game.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public void execute (params object[] parameters) {
            if (!isPaused) {
                audioManager.setMusicVolume(pauseMusicVolume);

                Time.timeScale = 0;
                startMenu.SetActive(true);
            } else {
                audioManager.resetMusicVolume();

                Time.timeScale = 1;
                startMenu.SetActive(false);
            }

            isPaused = !isPaused;
        }
    } 
}