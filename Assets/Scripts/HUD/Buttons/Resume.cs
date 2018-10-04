using UnityEngine;
using SpaceChaos.Resources;

namespace SpaceChaos.HUD.Buttons {
    /// <summary>
    /// Command for unpausing the game.
    /// </summary>
    /// <seealso cref="SpaceChaos.HUD.Buttons.ButtonCommand" />
    [AddComponentMenu("SpaceChaos/HUD/Buttons/Resume")]
    public class Resume : ButtonCommand {
        /// <summary>Pause system.</summary>
        [SerializeField]
        private Pause pause;

        /// <summary>
        /// Unpause the game.
        /// </summary>
        public override void execute () {
            base.execute();
            pause.execute();
        }
    } 
}