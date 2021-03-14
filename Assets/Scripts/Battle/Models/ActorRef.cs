using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
	public class ActorRef : MonoBehaviour
    {
        public IActor Actor { get; private set; }

        public IParticipant Owner { get; private set; }

            
        public ActorRef(IActor actor, IParticipant owner)
        {
            Actor = actor;
            Owner = owner;
        }
    }
}