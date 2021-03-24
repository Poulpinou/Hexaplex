using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexaplex.UI;

namespace Hexaplex.Battles.UI {
    public class ActorControlInterface : UIComponent
    {
        [Header("Components")]
        [SerializeField]
        private EndTurnButton endTurnButton;


        private ActorRef actorRef;


        public ActorRef ActorRef {
            get => actorRef;
            set {
                actorRef = value;
                OnActorChanged();
            }
        }


        private void OnActorChanged() {
        
        }

        protected override void OnHide()
        {
            endTurnButton.IsDisplayed = false;
        }

        protected override void OnShow()
        {
            endTurnButton.IsDisplayed = true;
        }
    }
}