namespace Hexaplex.Actions {
    public class GroupAction : GameAction
    {
        public readonly GameAction[] actions;

        private GroupAction(string name, params GameAction[] actions) : base(name)
        {
            this.actions = actions;
        }

        public static GroupAction Create(string name, params GameAction[] actions) => new GroupAction(name, actions);

        public static GroupAction Create(params GameAction[] actions) => Create(UNAMED_ACTION_NAME, actions);
    }
}