using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Hexaplex.Battles {
    public class InitBattleState : BattleState
    {
        protected override void OnEnter()
        {
            Debug.Log(string.Format("New battle started. Participants are:\n -{0}", string.Join("\n -", Battle.Sides.Select(s => s.ToString()))));
            
            if(Battle.Sides.Length > 2)
            {
                // TODO: Implement it!
                throw new System.NotImplementedException("Battles with more than two participants are not implementd yet.");
            }

            BattleManager.UI.BattleBanner.DrawText(
                string.Format("{0} VS {1}", Battle.Sides[0].Participant.Name, Battle.Sides[1].Participant.Name),
                () => Owner.ChangeState<ActorSelectionState>()
            );
        }

        protected override void OnExit()
        {

        }
    }
}