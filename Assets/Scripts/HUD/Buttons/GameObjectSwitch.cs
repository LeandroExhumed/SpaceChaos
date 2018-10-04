using UnityEngine;

namespace SpaceChaos.HUD.Buttons {
    /// <summary>
    /// Command for activating/deactivating a GameObject.
    /// </summary>
    /// <seealso cref="SpaceChaos.HUD.Buttons.ButtonCommand" />
    [AddComponentMenu("SpaceChaos/HUD/GameObjectSwitch")]
    public class GameObjectSwitch : ButtonCommand {
        /// <summary>Whether it's to activate the GameObject, if not, disable it.</summary>
        [Tooltip("Whether it's to activate the GameObject, if not, disable it.")]
        [SerializeField]
        private bool toActivate;

        /// <summary>GameObject to be activated/deactivated.</summary>
        [Tooltip("GameObject to be activated/deactivated.")]
        [SerializeField]
        private GameObject targetObject;

        /// <summary>
        /// Activate/deactivate the given GameObject.
        /// </summary>
        public override void execute () {
            base.execute();

            targetObject.SetActive(toActivate);
        }
    }
}