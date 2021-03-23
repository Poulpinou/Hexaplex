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


        private ActorQueueElement[] elements;


        protected override void OnClearDisplay()
        {
            foreach (ActorQueueElement element in elementsParent.GetComponentsInChildren<ActorQueueElement>())
            {
                Destroy(element.gameObject);
            }
        }     

        protected override void OnInitDisplay()
        {
            List<ActorQueueElement> elementList = new List<ActorQueueElement>();
            foreach (ActorRef actor in data.PredictedOrder)
            {
                ActorQueueElement element = Instantiate(elementModel, elementsParent.transform);
                element.Data = actor;
                elementList.Add(element);
            }

            elements = elementList.ToArray();

            OnRefreshDisplay();
        }

        protected override void OnRefreshDisplay()
        {
            ActorRef[] order = Data.PredictedOrder;
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i].Data = order[i];
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