using System.Collections.Generic;
using System.Linq;

namespace Hexaplex.StateMachines {
	public class StateHistory
    {
        public readonly int maxCount;

        private List<State> history;


        public State[] History => history.ToArray();

        public bool HasHistory => history.Count > 0;


        public StateHistory(int maxCount = int.MaxValue)
        {
            history = new List<State>();
            this.maxCount = maxCount;
        }


        public State GetPrevious()
        {
            return history.Last();
        }

        public State TakePrevious()
        {
            State state = GetPrevious();
            RemoveLast();

            return state;
        }

        public void Add(State state)
        {
            if(history.Count >= maxCount)
            {
                RemoveOldest();
            }
            history.Add(state);
        }

        public void Clear()
        {
            history = new List<State>();
        }

        public void RemoveLast()
        {
            if(HasHistory)
            {
                history.RemoveAt(history.Count - 1);
            }
        }

        private void RemoveOldest()
        {
            if (HasHistory)
            {
                history.RemoveAt(0);
            }
        }
    }
}