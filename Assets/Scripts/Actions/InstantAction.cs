namespace Hexaplex.Actions {
    /// <summary>
    /// This type of action can be executed in a single frame.
    /// Many enqueued <see cref="InstantAction"/> can be executed on the same frame
    /// </summary>
    public class InstantAction : GameAction
    {
        public delegate void Action();

        /// <summary>
        /// The delegate method to execute
        /// </summary>
        public readonly Action action;


        private InstantAction(string name, Action action) : base(name)
        {
            this.action = action;
        }


        public static InstantAction Create(string name, Action action) => new InstantAction(name, action);

        public static InstantAction Create(Action action) => Create(UNAMED_ACTION_NAME, action);
    }
}