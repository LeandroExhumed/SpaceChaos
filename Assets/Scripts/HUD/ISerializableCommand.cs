namespace SpaceChaos.HUD {
    /// <summary>
    /// A command to be executed with no parameter to be allowed to be used on Onclick events.
    /// </summary>
    public interface ISerializableCommand {
        /// <summary>
        /// Executes a command by clicking a button (no parameter allowed).
        /// </summary>
        void execute ();
    }
}