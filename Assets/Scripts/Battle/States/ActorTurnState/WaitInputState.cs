using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexaplex.Battles.UI;

namespace Hexaplex.Battles {
    public class WaitInputState : ActorTurnState
    {
        private readonly ActorControlInterface controlInterface;

        public WaitInputState()
        {
            controlInterface = BattleManager.UI.ActorControlInterface;
        }

        protected override void OnEnter(ActorTurnState previousState)
        {
            if (Owner.CurrentActor.Owner.IsControlledByPlayer())
            {
                controlInterface.ActorRef = Owner.CurrentActor;
                controlInterface.IsDisplayed = true;
            }
        }

        protected override void OnExit(ActorTurnState nextState)
        {
            if (controlInterface.IsDisplayed)
            {
                controlInterface.IsDisplayed = false;
            }
        }
    }
}