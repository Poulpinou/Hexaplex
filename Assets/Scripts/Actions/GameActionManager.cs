using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Hexaplex.Actions {
    /// <summary>
    /// Add this manager to your scene if you want to execute or queue some <see cref="GameAction"/>
    /// </summary>
	public class GameActionManager : StaticManager<GameActionManager>
    {
        #region Fields
        [Header("Editor")]
        [SerializeField]
        [Tooltip("If true, every action as well as the queue activity will be logged")]
        private bool logsEnabled;  


        private readonly Queue<GameAction> actionQueue = new Queue<GameAction>();

        private List<GameAction> actionsStack = new List<GameAction>();
        #endregion


        #region Properties
        /// <summary>
        /// True if there is at least <see cref="GameAction"/> in the action queue
        /// </summary>
        public bool ActionQueueIsRunning { get; private set; } = false;

        private GameAction CurrentAction => actionsStack.Last();

        private string CurrentActionFullName => string.Join("->", actionsStack.Select(action => action.Name));
        #endregion


        #region Static Methods
        /// <summary>
        /// Adds an <see cref="GameAction"/> to the action queue
        /// (using <see cref="GameAction.Enqueue"/> is a better practice)
        /// </summary>
        /// <param name="action">The <see cref="GameAction"/> to queue</param>
        public static void EnqueueAction(GameAction action)
        {
            Instance.actionQueue.Enqueue(action);

            if (!Instance.ActionQueueIsRunning)
            {
                Instance.StartCoroutine(Instance.RunQueue());
            }
        }

        /// <summary>
        /// Executes the provided <see cref="GameAction"/> instantly. It doesn't 
        /// affect the action queue (out of the flow)
        /// </summary>
        /// <param name="action">The <see cref="GameAction"/> to execute</param>
        public static void ExecuteAction(GameAction action) => Instance.StartCoroutine(Instance.ExecuteGameAction(action, true));

        /// <summary>
        /// Stops avery actions and clears the queue
        /// </summary>
        public static void StopAllActions() => Instance.StopAll();
        #endregion


        #region Methods
        private IEnumerator ExecuteGameAction(GameAction gameAction, bool outOfFlow = false)
        {
            if (!outOfFlow)
            {
                actionsStack.Add(gameAction);

                if (logsEnabled)
                {
                    Debug.LogFormat("Executing {0}: {1}", gameAction.GetType().Name, CurrentActionFullName);
                }
            }
            else
            {
                if (logsEnabled)
                {
                    Debug.LogFormat("Executing out of flow {0}: {1}", gameAction.GetType().Name, gameAction.Name);
                }
            }
            

            if (gameAction is InstantAction)
            {
                ExecuteInstantAction(gameAction as InstantAction, outOfFlow);
            }
            else if (gameAction is CoroutineAction)
            {
                yield return ExecuteCoroutineAction(gameAction as CoroutineAction, outOfFlow);
            }
            else if (gameAction is GroupAction)
            {
                yield return ExecuteGroupAction(gameAction as GroupAction, outOfFlow);
            }

            if (!outOfFlow)
            {
                actionsStack.Remove(gameAction);
            }
        }

        private IEnumerator ExecuteGroupAction(GroupAction action, bool outOfFlow = false)
        {
            IEnumerator<GameAction> actionEnumerator = action.actions.AsEnumerable().GetEnumerator();
            while (actionEnumerator.MoveNext())
            {
                yield return ExecuteGameAction(actionEnumerator.Current, outOfFlow);
            }

            if (logsEnabled)
            {
                Debug.LogFormat("Every actions in the group {0} were executed", action.Name);
            }
        }

        private void ExecuteInstantAction(InstantAction action, bool outOfFlow = false)
        {
            try
            {
                action.action();
            }
            catch (Exception e)
            {
                if(action.OnFailureCallback != null)
                {
                    action.OnFailureCallback(e);
                }
                else
                {
                    Debug.LogErrorFormat("{0} action failed: {1}", action.Name, e);
                }

                if (action.WillStopOnError)
                {
                    StopAll();
                }

                return;
            }

            action.OnSuccessCallback?.Invoke();
        }

        private IEnumerator ExecuteCoroutineAction(CoroutineAction action, bool outOfFlow = false)
        {
            IEnumerator enumerator = action.action();
            while (true)
            {
                object current;
                try
                {
                    if (enumerator.MoveNext() == false)
                    {
                        action.OnSuccessCallback?.Invoke();
                        break;
                    }
                    current = enumerator.Current;
                }
                catch (Exception e)
                {
                    action.OnFailureCallback?.Invoke(e);

                    if (action.WillStopOnError)
                    {
                        StopAll();
                    }

                    yield break;
                }
                yield return current;
            }
        }


        private IEnumerator RunQueue()
        {
            if (logsEnabled)
            {
                Debug.Log("Start reading queue");
            }

            ActionQueueIsRunning = true;

            while (actionQueue.Count > 0)
            {
                yield return ExecuteGameAction(actionQueue.Dequeue());
            }

            ActionQueueIsRunning = false;

            if (logsEnabled)
            {
                Debug.Log(string.Format("Action queue done"));
            }
        } 

        private void StopAll()
        {
            if (logsEnabled)
            {
                Debug.Log("Stopping all actions...");
            }
            
            StopAllCoroutines();
            actionQueue.Clear();
            actionsStack = new List<GameAction>();

            if (logsEnabled)
            {
                Debug.Log("All actions stopped");
            }
        }
        #endregion
    }
}