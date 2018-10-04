using System.Collections;
using UnityEngine;

namespace SpaceChaos.Player {
    /// <summary>
    /// Effect of the player ship blinking while it's invencible after reviving.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    /// <seealso cref="SpaceChaos.IBlinkable" />
    [AddComponentMenu("SpaceChaos/Player/UntouchableBlinking")]
    public class UntouchableBlinking : MonoBehaviour, IBlinkable {
        /// <summary>Times ship has blinked.</summary>
        private int timesBlinked = 0;
        /// <summary>Target number of times to blink.</summary>
        [SerializeField]
        private int timesToBlink = 10;
        /// <summary>Interval between the blinks.</summary>
        [SerializeField]
        private float blinkInterval = 0.2f;

        /// <summary>Mesh parts of the spaceship.</summary>
        [SerializeField]
        private GameObject[] meshes;

        /// <summary>Cached Collider component.</summary>
        private Collider c_boxCollider;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            c_boxCollider = GetComponent<Collider>();
        }

        /// <summary>
        /// Starts the blinking effect.
        /// </summary>
        public void startBlinking () {
            StartCoroutine(blinkingEffect());
        }

        /// <summary>
        /// The blinking process while player is invencible.
        /// </summary>
        /// <returns>
        /// The blinking.
        /// </returns>
        public IEnumerator blinkingEffect () {
            while (timesBlinked < timesToBlink) {
                setRenderersActive(false);
                yield return new WaitForSeconds(blinkInterval);
                setRenderersActive(true);
                timesBlinked++;
                yield return null;
            }

            c_boxCollider.enabled = true;
            timesBlinked = 0;
        }

        /// <summary>
        /// Activates/Deactivates the renderer components.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void setRenderersActive (bool value) {
            for (int i = 0; i < meshes.Length; i++) {
                meshes[i].SetActive(value);
            }
        }
    }
}