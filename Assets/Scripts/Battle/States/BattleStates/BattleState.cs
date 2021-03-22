using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexaplex.StateMachines;

namespace Hexaplex.Battles {
    public abstract class BattleState : State<BattleController>
    {
        protected Battle Battle => Owner.CurrentBattle;


        protected override void OnEnter(State previousState) => OnEnter(previousState as BattleState);

        protected override void OnExit(State nextState) => OnExit(nextState as BattleState);

        protected abstract void OnEnter(BattleState previousState);

        protected abstract void OnExit(BattleState nextState);
    }
}