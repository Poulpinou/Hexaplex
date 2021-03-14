using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Hexaplex.Battles {
	public class ActorQueue : IListenableData
    {
        private List<ActorProgress> actorProgresses;


        public ActorRef First => actorProgresses.Select(o => o.ActorRef).First();

        public List<ActorProgress> ActorProgresses => actorProgresses;

        public DataChangedEvent OnDataChanged { get; } = new DataChangedEvent();


        public ActorQueue(List<ActorRef> actors)
        {
            this.actorProgresses = actors.Select(a => new ActorProgress(a)).ToList();
        }

        public ActorQueue(params ActorRef[] actors) => new ActorQueue(new List<ActorRef>(actors));


        public void ComputeNext()
        {
            // Reset first actor progress
            actorProgresses.First().Progress = 0;
            actorProgresses = actorProgresses
                .OrderByDescending(a => a.Progress)
                .ThenByDescending(a => a.ActorRef.Actor.Speed)
                .ToList();

            // If there is no other with fulfilled progress...
            if (!actorProgresses.Any(a => a.Progress >= 1))
            {
                // ... compute new progress for every actors
                float maxSpeed = actorProgresses.Max(actors => actors.ActorRef.Actor.Speed);
                float progressDifference = 1 - actorProgresses.First().Progress;
                float speedFactor = progressDifference / maxSpeed;

                foreach (ActorProgress actorProgress in actorProgresses)
                {
                    actorProgress.Progress = Mathf.Clamp(speedFactor * actorProgress.ActorRef.Actor.Speed, 0, 1);
                }
            }

            OnDataChanged.Invoke();
        }
    }
}