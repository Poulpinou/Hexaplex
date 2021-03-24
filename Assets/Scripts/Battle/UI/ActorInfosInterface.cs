using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexaplex.UI;

namespace Hexaplex.Battles.UI {
    public class ActorInfosInterface : DataDisplay<ActorRef>
    {
        [SerializeField]
        private ActorDisplay actorDisplay;

        [SerializeField]
        private ParticipantDisplay participantDisplay;


        private DataDisplay[] DataDisplays => new DataDisplay[]{ actorDisplay, participantDisplay };


        protected override void OnHide()
        {
            foreach (DataDisplay display in DataDisplays) {
                display.IsDisplayed = false;
            }
        }

        protected override void OnShow()
        {
            foreach (DataDisplay display in DataDisplays)
            {
                display.IsDisplayed = true;
            }
        }

        protected override void OnInitDisplay()
        {
            actorDisplay.Data = Data.Actor;
            participantDisplay.Data = Data.Owner;
        }

        protected override void OnRefreshDisplay()
        {
            foreach (DataDisplay display in DataDisplays)
            {
                display.RefreshDisplay();
            }
        }

        protected override void OnClearDisplay()
        {
            foreach (DataDisplay display in DataDisplays)
            {
                display.ClearDisplay();
            }
        }
    }
}