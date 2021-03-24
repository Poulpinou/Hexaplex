using UnityEngine;

namespace Hexaplex {
	public class Settings : StaticManager<Settings>
    {
        [Header("Settings")]

        [SerializeField]
        private Battles.BattleSettings battleSettings;



        public static Battles.BattleSettings Battle => Instance.battleSettings;
    }

}