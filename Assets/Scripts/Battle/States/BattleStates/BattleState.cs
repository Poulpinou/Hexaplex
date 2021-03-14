using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexaplex.StateMachines;

namespace Hexaplex.Battles {
    public abstract class BattleState : State<BattleController>
    {
        protected Battle Battle => Owner.CurrentBattle;
    }
}