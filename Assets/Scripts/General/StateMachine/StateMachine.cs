using UnityEngine;
using UnityEngine.Events;
using System;

namespace Hexaplex.StateMachines {
    /// <summary>
    /// Basic state machine with history, override it for more complex behaviours
    /// </summary>
    public class StateMachine : MonoBehaviour
    {
        #region Events
        [Serializable]
        public class StateEvent : UnityEvent<State> { }
        #endregion


        #region Fields
        protected State currentState;

        protected StateHistory history = new StateHistory();
        #endregion


        #region Properties
        /// <summary>
        /// The current <see cref="State"/> of this <see cref="StateMachine"/>
        /// </summary>
        public State CurrentState => currentState;

        /// <summary>
        /// This event is called when <see cref="CurrentState"/> has been changed
        /// </summary>
        public StateEvent OnStateChanged { get; } = new StateEvent();

        /// <summary>
        /// Override this property with your default <see cref="State"/> if you need one
        /// </summary>
        protected virtual State DefaultState => null;

        /// <summary>
        /// Override this property with the <see cref="Type"/> of the parent of every <see cref="State"/>
        /// handled by your <see cref="StateMachine"/>. Other <see cref="State"/>s will throw an Exception.
        /// </summary>
        protected virtual Type ConstraintType => null;
        #endregion


        #region Methods
        /// <summary>
        /// Use this method to change the current state of the <see cref="StateMachine"/>
        /// </summary>
        /// <typeparam name="T">The type of the state (it should have a no param constructor)</typeparam>
        public void ChangeState<T>() where T : State, new()
        {
            ChangeState(new T());
        }

        /// <summary>
        ///  Use this method to change the current state of the <see cref="StateMachine"/>
        /// </summary>
        /// <param name="state">The new state</param>
        public void ChangeState(State state)
        {
            if (ConstraintType != null && !ConstraintType.IsAssignableFrom(state.GetType()))
            {
                throw new Exception(string.Format("Impossible to change state to {0}: only {1}s are allowed", state.GetType().Name, ConstraintType.Name));
            }

            TransitionToNewState(state);
        }

        /// <summary>
        /// Une this method to come back to the previous state. It will fail if the state is not <see cref="State.Reversable"/>
        /// or if there is no previous state
        /// </summary>
        public void PreviousState()
        {
            if (CurrentState == null)
            {
                throw new Exception("Impossible to come back to previous State: no current state");
            }

            if (!CurrentState.Reversable)
            {
                throw new Exception(string.Format("Impossible to come back to previous State: {0} is not reversable", CurrentState.GetType().Name));
            }

            if (!history.HasHistory)
            {
                throw new Exception("Impossible to come back to previous State: history is empty");
            }

            TransitionToNewState(history.TakePrevious(), false);
        }

        private void TransitionToNewState(State newState, bool handleHistory = true)
        {
            State lastState = currentState;
            lastState?.Exit();

            currentState = newState;

            currentState?.Enter(this);

            if (handleHistory)
            {
                if (currentState?.Reversable ?? false)
                {
                    history.Add(lastState);
                }
                else
                {
                    history.Clear();
                }
            }

            OnStateChanged.Invoke(currentState);
        }
        #endregion

        #region Runtime Methods
        private void Awake()
        {
            if (DefaultState != null)
            {
                TransitionToNewState(DefaultState);
            }
        } 
        #endregion
    }
}