using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Hexaplex.Battles {
	public class Battle
    {
        private List<BattleSide> sides;

        public BattleSide[] Sides => sides.ToArray();

        
        public Battle(params BattleSide[] sides)
        {
            this.sides = new List<BattleSide>(sides);

            if(sides.Length < 2)
            {
                throw new Exception("A battle should at least have 2 sides");
            }
        }
    }
}