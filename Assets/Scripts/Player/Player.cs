using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Hexaplex.Battles;

namespace Hexaplex.Players {
    [Serializable]
    public class Player : IParticipant
    {
        [SerializeField]
        private string name;

        [SerializeField]
        private Sprite picture;


        public string Name => name;

        public ControllerType ControllerType => ControllerType.CurrentPlayer;

        public Sprite Picture => picture;
    }
}