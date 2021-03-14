using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
    public class ActorSelectionState : BattleState
    {
        protected override void OnEnter()
        {
            Owner.ActorQueue.ComputeNext();

            Owner.ChangeState(new ActorPlayingState(Owner.ActorQueue.First));
        }

        protected override void OnExit()
        {
            
        }
    }
}