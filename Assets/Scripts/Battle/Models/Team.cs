using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Hexaplex.Characters;

namespace Hexaplex.Battles {

    public class Team : ITeam
    {
        private List<IActor> actors;

        public virtual List<IActor> Actors => actors;

        public Team(params IActor[] actors)
        {
            this.actors = new List<IActor>(actors);
        }
    }

    public class Team<T> : Team where T: IActor
    {
        [SerializeField]
        private List<T> actors;


        public override List<IActor> Actors => actors.Cast<IActor>().ToList();


        public Team(params T[] actors)
        {
            this.actors = new List<T>(actors);
        }

        public override string ToString()
        {
            return string.Join(", ", actors.Select(c => c.ToString()));
        }
    }

    [Serializable]
    public class CharacterTeam : Team<Character> { }
}