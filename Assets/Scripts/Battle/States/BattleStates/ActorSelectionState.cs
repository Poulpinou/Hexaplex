using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
    public class ActorSelectionState : BattleState
    {
        protected override void OnEnter(BattleState previousState)
        {
            if(BattleManager.UI.ActorQueueDisplay.Data == null)
            {
                BattleManager.UI.ActorQueueDisplay.Data = Owner.ActorQueue;
                BattleManager.UI.ActorQueueDisplay.IsDisplayed = true;

                // Fake wait instead of animation for now
                LeanTween.delayedCall(1, () => {
                    Owner.ChangeState(new ActorPlayingState(Owner.ActorQueue.First));
                });
            }
            else
            {
                // Fake wait instead of animation for now
                LeanTween.delayedCall(1, () => {
                    Owner.ChangeState(new ActorPlayingState(Owner.ActorQueue.GetNext()));
                });
            }
        }

        protected override void OnExit(BattleState nextState)
        {
            
        }
    }
}