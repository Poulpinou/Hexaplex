using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
	public class BattleSide
    {
        public IParticipant Participant { get; private set; }

        public ITeam Team { get; private set; }


        public BattleSide(IParticipant participant, ITeam team)
        {
            Participant = participant;
            Team = team;
        }


        public override string ToString()
        {
            return string.Format("{0}({1}): {2}", Participant.Name, Participant.ControllerType, Team.ToString());
        }
    }
}