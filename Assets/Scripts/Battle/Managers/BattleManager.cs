using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Hexaplex.Battles.UI;

namespace Hexaplex.Battles {
	public class BattleManager : StaticManager<BattleManager>
    {
        [SerializeField]
        private BattleController battleController;

        [SerializeField]
        private ActorTurnController characterTurnController;

        [SerializeField]
        private UIReference UIReferences;


        public static BattleController BattleController => Instance.battleController;

        public static ActorTurnController CharacterTurnController => Instance.characterTurnController;

        public static UIReference UI => Instance.UIReferences;


        [Serializable]
        public class UIReference
        {
            [SerializeField]
            private BattleBanner battleBanner;

            [SerializeField]
            private ActorQueueDisplay actorQueueDisplay;

            [SerializeField]
            private ActorControlInterface actorControlInterface;

            [SerializeField]
            private ActorInfosInterface actorInfosInterface;


            public BattleBanner BattleBanner => battleBanner;

            public ActorQueueDisplay ActorQueueDisplay => actorQueueDisplay;

            public ActorControlInterface ActorControlInterface => actorControlInterface;

            public ActorInfosInterface ActorInfosInterface => actorInfosInterface;
        }
    }
}