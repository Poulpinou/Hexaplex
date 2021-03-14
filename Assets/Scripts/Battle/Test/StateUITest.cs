using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hexaplex.StateMachines;

namespace Hexaplex.Battles.Test {
	public class StateUITest : MonoBehaviour
    {
        [SerializeField]
        private Text stateNameText;


        private void OnStateChanged(State state)
        {
            stateNameText.text = string.Format(
                "{0}({1})", 
                BattleManager.BattleController.CurrentState?.GetType().Name ?? "No State", 
                BattleManager.CharacterTurnController.CurrentState?.GetType().Name ?? "No State"
            );
        }

        private void Start()
        {
            BattleManager.BattleController.OnStateChanged.AddListener(OnStateChanged);
            BattleManager.CharacterTurnController.OnStateChanged.AddListener(OnStateChanged);
        }
    }
}