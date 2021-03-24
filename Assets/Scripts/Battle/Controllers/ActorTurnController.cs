using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexaplex.StateMachines;
using System;

namespace Hexaplex.Battles {
	public class ActorTurnController : StateMachine
    {
        public Action TurnDoneCallback { get; private set; }

        public ActorRef CurrentActor { get; private set; }


        protected override State DefaultState => new WaitNewTurnState();


        public void StartTurn(ActorRef actor, Action turnDoneCallback) {
            if (!(CurrentState is WaitNewTurnState)) {
                throw new Exception(string.Format("Can't start a new turn when {0} is in {1}", GetType().Name, CurrentState.GetType().Name));
            }

            CurrentActor = actor;
            TurnDoneCallback = turnDoneCallback;

            ChangeState<StartTurnState>();
        }
    }
}