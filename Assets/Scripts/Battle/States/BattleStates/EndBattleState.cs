using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
    public class EndBattleState : BattleState
    {
        protected override void OnEnter(BattleState previousState)
        {
            BattleManager.UI.BattleBanner.DrawText("Fin du match!");
            BattleManager.UI.ActorQueueDisplay.IsDisplayed = false;
        }

        protected override void OnExit(BattleState nextState)
        {
            throw new System.NotImplementedException();
        }
    }
}