using UnityEngine;

namespace Hexaplex.StateMachine {
    /// <summary>
    /// This is the main class for every states that will be used by a <see cref="StateMachine"/>
    /// </summary>
	public abstract class State
    {
        /// <summary>
        /// The <see cref="StateMachine"/> that owns the <see cref="State"/>
        /// </summary>
        public StateMachine Owner { get; protected set; }

        /// <summary>
        /// If true and if this <see cref="State"/> is the current state, the <see cref="StateMachine"/> can
        /// go to previous state (see <see cref="StateMachine.PreviousState"/>)
        /// </summary>
        public virtual bool Reversable => false;


        internal virtual void Enter(StateMachine owner) {
            Owner = owner;
            OnEnter();
        }

        internal void Exit() => OnExit();

        protected abstract void OnEnter();

        protected abstract void OnExit();
    }


    /// <summary>
    /// This class is the same as <see cref="State"/> but it has a type contraint
    /// for its <see cref="StateMachine"/>
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="StateMachine"/></typeparam>
    public abstract class State<T> : State where T: StateMachine
    {
        public new T Owner => base.Owner as T;

        internal override sealed void Enter(StateMachine owner)
        {
            if(!(owner is T))
            {
                Debug.LogErrorFormat("The owner of a {0} should be a {1} but a {2} has been provided!", GetType().Name, typeof(T).Name, owner.GetType().Name);
            }
            base.Enter(owner);
        }
    }
}