using System.Collections;
using System;

namespace Hexaplex.Actions {
    /// <summary>
    /// This class represents an action executed by the <see cref="GameActionManager"/>.
    /// Its purpose is to centralize the way to perfom actions.
    /// </summary>
	public abstract class GameAction
    {
        protected const string UNAMED_ACTION_NAME = "Unamed";


        public delegate void FailureCallback(Exception e);

        public delegate void SuccessCallback();


        /// <summary>
        /// The <see cref="GameAction"/>'s name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The method which is called if an error occured during the execution
        /// </summary>
        public FailureCallback OnFailureCallback { get; private set; }

        /// <summary>
        /// The method which is called when action has been executed successfully
        /// </summary>
        public SuccessCallback OnSuccessCallback { get; private set; }

        /// <summary>
        /// If true, the current action queue will stop if an error occured.
        /// Ignored if the action is called with <see cref="Execute"/>
        /// </summary>
        public bool WillStopOnError { get; private set; }


        protected GameAction(string name)
        {
            Name = name;
        }


        /// <summary>
        /// Add this <see cref="GameAction"/> to the <see cref="GameActionManager"/>'s action queue.
        /// A queued <see cref="GameAction"/> will be performed after every previously queued actions
        /// </summary>
        public void Enqueue() => GameActionManager.EnqueueAction(this);

        /// <summary>
        /// Asks the <see cref="GameActionManager"/> to instantly execute this <see cref="GameAction"/>
        /// </summary>
        public void Execute() => GameActionManager.ExecuteAction(this);


        /// <summary>
        /// Sets the <see cref="OnFailureCallback"/>
        /// </summary>
        /// <param name="callback">The method to call on failure</param>
        /// <returns>Self</returns>
        public GameAction OnFailure(FailureCallback callback)
        {
            OnFailureCallback = callback;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="OnSuccessCallback"/>
        /// </summary>
        /// <param name="callback">The method to call on success</param>
        /// <returns>Self</returns>
        public GameAction OnSuccess(SuccessCallback callback)
        {
            OnSuccessCallback = callback;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="WillStopOnError"/>
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>Self</returns>
        public GameAction StopOnError(bool value)
        {
            WillStopOnError = value;
            return this;
        }
    }
}