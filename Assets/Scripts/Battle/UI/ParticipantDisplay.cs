using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hexaplex.UI;
using Hexaplex.UI.Animations;

namespace Hexaplex.Battles.UI {
    public class ParticipantDisplay : DataDisplay<IParticipant>
    {
        [Header("Relations")]
        [SerializeField]
        private Image pictureImage;

        [SerializeField]
        private Text nameText;

        [SerializeField]
        private Image border;


        [Header("Animations")]
        [SerializeField]
        private Translate showHideAnimation;


        protected override void OnClearDisplay()
        {
            pictureImage.sprite = null;
            nameText.text = null;
        }

        protected override void OnRefreshDisplay()
        {
            pictureImage.sprite = Data.Picture;
            nameText.text = Data.Name;
            border.color = Data.ControllerType == ControllerType.CurrentPlayer ? Settings.Battle.SelfColor : Settings.Battle.EnemyColor;
        }

        protected override void OnShow()
        {
            showHideAnimation.Play(gameObject);
        }

        protected override void OnHide()
        {
            showHideAnimation.PlayReversed(gameObject);
        }
    }
}