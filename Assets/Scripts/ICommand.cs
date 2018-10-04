namespace SpaceChaos {
    /// <summary>
    /// Common interface for Command pattern implementers.
    /// </summary>
    public interface ICommand {
        /// <summary>
        /// Executes a specific command.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        void execute (params object[] parameters);
    }
}