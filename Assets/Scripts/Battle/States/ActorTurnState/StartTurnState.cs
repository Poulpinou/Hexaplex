using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexaplex.Battles.UI;

namespace Hexaplex.Battles {
    public class StartTurnState : ActorTurnState
    {
        protected override void OnEnter(ActorTurnState previousState)
        {
            BattleManager.UI.BattleBanner.DrawText(string.Format("Tour de {0}", CurrentActor.Actor.Name));

            BattleManager.UI.ActorInfosInterface.Data = Owner.CurrentActor;
            BattleManager.UI.ActorInfosInterface.IsDisplayed = true;

            Owner.ChangeState<WaitInputState>();
        }

        protected override void OnExit(ActorTurnState nextState)
        {

        }
    }
}