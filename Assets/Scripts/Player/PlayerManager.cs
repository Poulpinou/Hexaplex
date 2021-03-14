using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Players {
	public class PlayerManager : StaticManager<PlayerManager>
    {
        [SerializeField]
        private Player currentPlayer;


        public static Player CurrentPlayer => Instance.currentPlayer;
    }
}