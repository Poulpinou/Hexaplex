using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
    public class ActorPlayingState : BattleState
    {
        public ActorRef CurrentActor { get; private set; }


        public ActorPlayingState(ActorRef actorRef)
        {
            CurrentActor = actorRef;
        }

        protected override void OnEnter()
        {
            BattleManager.UI.BattleBanner.DrawText(string.Format("Tour de {0}", CurrentActor.Actor.Name));
        }

        protected override void OnExit()
        {
            throw new System.NotImplementedException();
        }
    }
}