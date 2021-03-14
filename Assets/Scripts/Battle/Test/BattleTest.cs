using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexaplex.Players;

namespace Hexaplex.Battles.Test {
	public class BattleTest : MonoBehaviour
    {
        [Header("Current player")]
        [SerializeField]
        private CharacterTeam playersTeam;

        [Header("Opponent")]
        [SerializeField]
        private ComputerOpponent opponent;

        [SerializeField]
        private CharacterTeam opponentsTeam;


        private void Start()
        {
            Battle battle = new Battle(
                new BattleSide(PlayerManager.CurrentPlayer, playersTeam),
                new BattleSide(opponent, opponentsTeam)
            );

            BattleManager.BattleController.StartBattle(battle);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BattleManager.BattleController.ActorQueue.ComputeNext();
            }
        }
    }
}