using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hexaplex.Battles {
	public class BattleManager : StaticManager<BattleManager>
    {
        [SerializeField]
        private BattleController battleController;

        [SerializeField]
        private CharacterTurnController characterTurnController;

        [SerializeField]
        private UIReference UIReferences;


        public static BattleController BattleController => Instance.battleController;

        public static CharacterTurnController CharacterTurnController => Instance.characterTurnController;

        public static UIReference UI => Instance.UIReferences;


        [Serializable]
        public class UIReference
        {
            [SerializeField]
            private BattleBanner battleBanner;


            public BattleBanner BattleBanner => battleBanner;
        }
    }
}