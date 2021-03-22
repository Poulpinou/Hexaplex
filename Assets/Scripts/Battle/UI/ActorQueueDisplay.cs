using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hexaplex.UI;

namespace Hexaplex.Battles.UI {
    [RequireComponent(typeof(RectTransform))]
    public class ActorQueueDisplay : DataDisplay<ActorQueue>
    {
        [Header("Relations")]
        [SerializeField]
        private LayoutGroup elementsParent;

        [SerializeField]
        private ActorQueueElement elementModel;


        [Header("Animation")]
        [SerializeField]
        private Vector2 closedPosition;

        [SerializeField]
        private Vector2 openedPosition;


        protected override void OnClearDisplay()
        {
            foreach (ActorQueueElement element in elementsParent.GetComponentsInChildren<ActorQueueElement>())
            {
                Destroy(element.gameObject);
            }
        }     

        protected override void OnInitDisplay()
        {
            foreach (ActorProgress actorProgress in data.ActorProgresses)
            {
                ActorQueueElement element = Instantiate(elementModel, elementsParent.transform);
                element.Data = actorProgress;
            }

            OnRefreshDisplay();
        }

        protected override void OnRefreshDisplay()
        {
            List<ActorProgress> progresses = data.ActorProgresses;

            foreach(ActorQueueElement element in elementsParent.GetComponentsInChildren<ActorQueueElement>())
            {
                element.transform.SetSiblingIndex(progresses.IndexOf(element.Data));
            }
        }

        protected override void OnShow()
        {
            RectTransform.anchoredPosition = closedPosition;

            LeanTween.move(RectTransform, openedPosition, 0.5f)
                .setOnComplete(() => RectTransform.anchoredPosition = openedPosition);
        }

        protected override void OnHide()
        {
            RectTransform.anchoredPosition = openedPosition;

            LeanTween.move(RectTransform, closedPosition, 0.5f)
                .setOnComplete(() => RectTransform.anchoredPosition = closedPosition);
        }
    }
}