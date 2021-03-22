using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Hexaplex.UI;

namespace Hexaplex.Battles.UI {
	public class EndTurnButton : UIComponent
    {
        [Header("Realations")]
        [SerializeField]
        private Button button;

        [Header("Animation")]
        [SerializeField]
        private Vector2 shownPosition;

        [SerializeField]
        private Vector2 hiddenPosition;


        protected override void OnHide()
        {
            button.interactable = false;

            RectTransform.anchoredPosition = shownPosition;

            LeanTween.move(RectTransform, hiddenPosition, 0.3f)
                .setOnComplete(() => RectTransform.anchoredPosition = hiddenPosition);
        }

        protected override void OnShow()
        {
            RectTransform.anchoredPosition = hiddenPosition;

            LeanTween.move(RectTransform, shownPosition, 0.3f)
                .setOnComplete(() => {
                    RectTransform.anchoredPosition = shownPosition;
                    button.interactable = true;
                });
        }

        protected override void Awake()
        {
            base.Awake();
            RectTransform.anchoredPosition = hiddenPosition;
        }

        private void Start()
        {
            button.onClick.AddListener(BattleManager.CharacterTurnController.ChangeState<EndTurnState>);
        }
    }
}