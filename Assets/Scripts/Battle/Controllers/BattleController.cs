using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Hexaplex.StateMachines;

namespace Hexaplex.Battles {
	public class BattleController : StateMachine
    {
        public Battle CurrentBattle { get; private set; }

        protected override Type ConstraintType => typeof(BattleState);

        public ActorQueue ActorQueue { get; private set; }


        public void StartBattle(Battle battle)
        {
            if(CurrentBattle != null)
            {
                throw new Exception("A battle has already started, you can't start another now");
            }

            CurrentBattle = battle;

            List<ActorRef> actorRefs = CurrentBattle.Sides
                .SelectMany(
                    side => side.Team.Actors,
                    (side, actor) => new ActorRef(actor, side.Participant)
                )
                .ToList();

            ActorQueue = new ActorQueue(actorRefs);

            ChangeState<InitBattleState>();
        }
    }
}