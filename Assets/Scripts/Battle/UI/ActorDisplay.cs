using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hexaplex.UI;

namespace Hexaplex.Battles.UI {
    public class ActorDisplay : DataDisplay<IActor>
    {
        [SerializeField]
        private Image actorPicture;

        protected override void OnClearDisplay()
        {
            actorPicture.sprite = null;
        }

        protected override void OnRefreshDisplay()
        {
            actorPicture.sprite = Data.Picture;
        }

        protected override void OnShow()
        {
            actorPicture.enabled = true;
        }

        protected override void OnHide()
        {
            actorPicture.enabled = false;
        }
    }
}