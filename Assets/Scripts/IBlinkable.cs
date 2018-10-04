using System.Collections;

namespace SpaceChaos {
    /// <summary>
    /// Common interface for the different blinking effects.
    /// </summary>
    public interface IBlinkable {
        /// <summary>
        /// Starts the blinking effect.
        /// </summary>
        void startBlinking ();
        /// <summary>
        /// The blinking process.
        /// </summary>
        /// <returns>The blinking.</returns>
        IEnumerator blinkingEffect ();
    }
}