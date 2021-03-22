﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
    public class ActorSelectionState : BattleState
    {
        protected override void OnEnter(BattleState previousState)
        {
            Owner.ActorQueue.ComputeNext();

            LeanTween.delayedCall(1, () =>
            {
                Owner.ChangeState(new ActorPlayingState(Owner.ActorQueue.First));
            });
        }

        protected override void OnExit(BattleState nextState)
        {
            
        }
    }
}