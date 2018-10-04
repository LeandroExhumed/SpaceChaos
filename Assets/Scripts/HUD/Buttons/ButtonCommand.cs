using SpaceChaos.AudioSystem;
using UnityEngine;

namespace SpaceChaos.HUD.Buttons {
    /// <summary>
    /// Common behaviour for UI Buttons.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.HUD.ISerializableCommand" />
    [AddComponentMenu("SpaceChaos/HUD/Buttons")]
    public class ButtonCommand : MonoBehaviour, ISerializableCommand {
        /// <summary>Sound manager of the game.</summary>
        [SerializeField]
        protected AudioManager audioManager;

        /// <summary>
        /// Executes a button command when clicking.
        /// </summary>
        public virtual void execute () {
            audioManager.playSound(AudioManager.SoundType.ButtonPress);
        }
    }
}