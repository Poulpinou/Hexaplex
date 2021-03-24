using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
    public class EndCheckState : BattleState
    {
        protected override void OnEnter(BattleState previousState)
        {
            // Temporary rule, just for testing purpose
            if(Time.realtimeSinceStartup > 60)
            {
                Owner.ChangeState<EndBattleState>();
            }
            else {
                Owner.ChangeState<ActorSelectionState>();
            }
        }

        protected override void OnExit(BattleState nextState)
        {
        }
    }
}