using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexaplex.StateMachines;

namespace Hexaplex.Battles {
    public abstract class ActorTurnState : State<ActorTurnController>
    {
        public ActorRef CurrentActor => Owner.CurrentActor;


        protected override void OnEnter(State previousState) => OnEnter(previousState as ActorTurnState);

        protected override void OnExit(State nextState) => OnExit(nextState as ActorTurnState);

        protected abstract void OnEnter(ActorTurnState previousState);

        protected abstract void OnExit(ActorTurnState nextState);
    }
}