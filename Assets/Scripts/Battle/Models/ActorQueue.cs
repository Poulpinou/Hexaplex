using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Hexaplex.Battles {
    public class ActorQueue : IListenableData
    { 
        // TODO: Export it in global configuration
        private const int PREDICTED_TURNS_AMOUNT = 10;


        private readonly List<ActorInQueue> actorsInQueue;

        private readonly List<ActorRef> predictedOrder = new List<ActorRef>();

        private ActorInQueue current;


        public ActorRef[] PredictedOrder => predictedOrder.ToArray();

        public ActorRef First => current.Actor;

        public DataChangedEvent OnDataChanged { get; } = new DataChangedEvent();


        public ActorQueue(List<ActorRef> actors)
        {
            actorsInQueue = new List<ActorInQueue>(actors.Select(actor => new ActorInQueue(actor)));

            ComputeNext();
        }


        public ActorRef GetNext() {
            ComputeNext();
            return First;
        }

        public void ComputeNext() {
            if (current != null) {
                // Decrement current
                current.RealProgress--;
            }

            // Increment real progress for all
            if(!actorsInQueue.Any(a => a.RealProgress >= 1)) {
                float maxSpeed = actorsInQueue.Max(actors => actors.Actor.Actor.Speed);
                foreach (ActorInQueue actorInQueue in actorsInQueue)
                {
                    actorInQueue.RealProgress += actorInQueue.Actor.Actor.Speed / maxSpeed;
                }
            }

            // Choose new current from real progress
            current = actorsInQueue.OrderByDescending(a => a.RealProgress).First();

            Debug.LogFormat("{0} is in [{1}]?", current.Actor.Actor.Name, string.Join(",", predictedOrder.Select(a => a.Actor.Name)));

            // If predicted is equal tu current...
            if (predictedOrder.Count > 0 && predictedOrder[0] == current.Actor)
            {
                // Remove first prediction
                predictedOrder.RemoveAt(0);

                // Compute the next one
                ComputePredictions();
            }
            else {
                // Invalidate if not
                Debug.Log("Invalid predictions, recomputing...");
                RecomputePredictions();
            }
        }

        private void RecomputePredictions() {
            predictedOrder.Clear();

            foreach (ActorInQueue actorInQueue in actorsInQueue)
            {
                actorInQueue.PredictedProgress = actorInQueue.RealProgress;
            }

            ComputePredictions();
        }

        private void ComputePredictions() {
            float maxSpeed = actorsInQueue.Max(actors => actors.Actor.Actor.Speed);

            ActorInQueue current = actorsInQueue.OrderByDescending(a => a.PredictedProgress).First();
            while (predictedOrder.Count < PREDICTED_TURNS_AMOUNT) {
                current.PredictedProgress--;

                if (!actorsInQueue.Any(a => a.PredictedProgress >= 1)) {
                    foreach (ActorInQueue actorInQueue in actorsInQueue)
                    {
                        actorInQueue.PredictedProgress += actorInQueue.Actor.Actor.Speed / maxSpeed;
                    }
                }

                current = actorsInQueue.OrderByDescending(a => a.PredictedProgress).First();
                predictedOrder.Add(current.Actor);
            }

            OnDataChanged.Invoke();
        }


        private class ActorInQueue
        {

            public ActorRef Actor { get; private set; }

            public float RealProgress { get; set; } = 0;

            public float PredictedProgress { get; set; } = 0;


            public ActorInQueue(ActorRef actorRef)
            {
                Actor = actorRef;
            }
        }
    }
}