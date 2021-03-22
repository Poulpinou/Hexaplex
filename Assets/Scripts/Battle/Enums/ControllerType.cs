namespace Hexaplex.Battles {
    public enum ControllerType
    {
        /// <summary>
        /// Controlled by the current player (the one defined by <see cref="Players.PlayerManager.CurrentPlayer"/>)
        /// </summary>
        CurrentPlayer,

        /// <summary>
        /// Controlled by another human player (for online purpose)
        /// </summary>
        OtherPlayer,

        /// <summary>
        /// Controlled by the current player as the AI (but stil considered as not controlled by player)
        /// </summary>
        SimulatedPlayer,

        /// <summary>
        /// Controlled by an AI
        /// </summary>
        AI
    }
}