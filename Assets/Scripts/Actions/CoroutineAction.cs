using System.Collections;

namespace Hexaplex.Actions {
    public class CoroutineAction : GameAction
    {
        public delegate IEnumerator Action();

        /// <summary>
        /// The delegate coroutine to execute
        /// </summary>
        public readonly Action action;

        private CoroutineAction(string name, Action action) : base(name)
        {
            this.action = action;
        }

        public static CoroutineAction Create(string name, Action action) => new CoroutineAction(name, action);

        public static CoroutineAction Create(Action action) => Create(UNAMED_ACTION_NAME, action);
    }
}