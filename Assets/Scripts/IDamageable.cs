namespace SpaceChaos {
    /// <summary>
    /// Common interface for entities that suffers damage in some way.
    /// </summary>
    public interface IDamageable {
        /// <summary>
        /// Takes an attack damage.
        /// </summary>
        /// <param name="damage">The damage value to suffer.</param>
        void takeDamage ();
    }
}