namespace SpaceChaos.Resources.InputSystem {
    /// <summary>
    /// Common interface for all type of input.
    /// </summary>
    public interface IGameInput {
        /// <summary>
        /// Gets the horizontal input value.
        /// </summary>
        /// <returns></returns>
        float getHorizontalAxis ();
        /// <summary>
        /// Gets the vertical input value.
        /// </summary>
        /// <returns></returns>
        float getVerticalAxis ();
        /// <summary>
        /// Whether the shoting button is being pressed.
        /// </summary>
        /// <returns></returns>
        bool isShoting ();
        /// <summary>
        /// Whether the pause button is being pressed.
        /// </summary>
        /// <returns></returns>
        bool isPausing ();
    } 
}