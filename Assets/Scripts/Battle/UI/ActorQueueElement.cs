using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hexaplex.UI;

namespace Hexaplex.Battles.UI {
    public class ActorQueueElement : DataDisplay<ActorProgress>
    {
        [SerializeField]
        private Image actorPictureImage;

        [SerializeField]
        private Text actorNameText;

        [SerializeField]
        private Slider progressSlider;


        protected override void OnClearDisplay()
        {
            actorPictureImage.sprite = null;
            actorNameText.text = "";
            progressSlider.value = 0;
        } 

        protected override void OnRefreshDisplay()
        {
            actorNameText.text = Data.ActorRef.Actor.Name;
            actorPictureImage.sprite = Data.ActorRef.Actor.Picture;
            progressSlider.value = Data.Progress;
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }
    }
}