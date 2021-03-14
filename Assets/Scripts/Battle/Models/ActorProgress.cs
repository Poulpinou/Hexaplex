using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
    public class ActorProgress : IListenableData
    {
        private float progress;


        public ActorRef ActorRef { get; private set; }

        public float Progress {
            get => progress;
            set
            {
                progress = value;
                OnDataChanged.Invoke();
            }
        }

        public DataChangedEvent OnDataChanged { get; } = new DataChangedEvent();


        public ActorProgress(ActorRef actorRef, float progress = 0)
        {
            ActorRef = actorRef;
            Progress = progress;
        }
    }
}