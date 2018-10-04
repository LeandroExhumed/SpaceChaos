using UnityEngine;

namespace SpaceChaos.HUD.Effects {
    /// <summary>
    /// Animation of the loading circle icon rotating.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("Asteroids/HUD/Effects/LoadingAnimation")]
    public class LoadingAnimation : MonoBehaviour {
        /// <summary>Degree that the icon rotates.</summary>
        public Vector3 rotationDegree;

        /// <summary>
        /// Updates this instance.
        /// </summary>
        private void Update () {
            transform.Rotate(rotationDegree * Time.deltaTime);
        }
    } 
}