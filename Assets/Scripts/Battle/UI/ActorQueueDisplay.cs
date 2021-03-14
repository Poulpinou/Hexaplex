using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hexaplex.UI;

namespace Hexaplex.Battles.UI {
    public class ActorQueueDisplay : DataDisplay<ActorQueue>
    {
        [SerializeField]
        private LayoutGroup elementsParent;

        [SerializeField]
        private ActorQueueElement elementModel;

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
        }

        protected override void OnRefreshDisplay()
        {
            List<ActorProgress> progresses = data.ActorProgresses;

            foreach(ActorQueueElement element in elementsParent.GetComponentsInChildren<ActorQueueElement>())
            {
                element.transform.SetSiblingIndex(progresses.IndexOf(element.Data));
            }
        }

        private void Start()
        {
            BattleManager.BattleController.OnStateChanged.AddListener(delegate {
                Data = BattleManager.BattleController.ActorQueue;
            });
        }
    }
}