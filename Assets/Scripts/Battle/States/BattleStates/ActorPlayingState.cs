using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
    public class ActorPlayingState : BattleState
    {
        private ActorRef currentActor;

        private ActorTurnController turnController;


        public ActorPlayingState(ActorRef actorRef)
        {
            currentActor = actorRef;
            turnController = BattleManager.CharacterTurnController;
        }

        protected override void OnEnter(BattleState previousState)
        {
            turnController.StartTurn(currentActor, Owner.ChangeState<EndCheckState>);
        }

        protected override void OnExit(BattleState nextState) { }
    }
}