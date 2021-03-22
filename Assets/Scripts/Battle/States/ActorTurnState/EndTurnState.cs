using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
    public class EndTurnState : ActorTurnState
    {
        protected override void OnEnter(ActorTurnState previousState)
        {
            Owner.ChangeState<WaitNewTurnState>();
        }

        protected override void OnExit(ActorTurnState nextState)
        {
            BattleManager.UI.ActorInfosInterface.IsDisplayed = false;

            Owner.TurnDoneCallback.Invoke();
        }
    }
}