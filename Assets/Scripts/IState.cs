namespace SpaceChaos {
    /// <summary>
    /// Represents a state within a Finite Machine State.
    /// </summary>
    public interface IState {
        /// <summary>
        /// Starts the state.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        void onEnter (params object[] parameters);
        /// <summary>
        /// Executes the state action.
        /// </summary>
        void onUpdate ();
        /// <summary>
        /// Handles what is needed before leaving this state.
        /// </summary>
        void onExit ();
    } 
}