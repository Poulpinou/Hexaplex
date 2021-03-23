using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hexaplex.UI;

namespace Hexaplex.Battles.UI {
    public class ActorQueueElement : DataDisplay<ActorRef>
    {
        [SerializeField]
        private Image actorPictureImage;

        [SerializeField]
        private Text actorNameText;


        protected override void OnClearDisplay()
        {
            actorPictureImage.sprite = null;
            actorNameText.text = "";
        } 

        protected override void OnRefreshDisplay()
        {
            actorNameText.text = Data.Actor.Name;
            actorPictureImage.sprite = Data.Actor.Picture;
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }
    }
}