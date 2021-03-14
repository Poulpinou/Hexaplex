using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexaplex.Battles;
using System;

namespace Hexaplex.Characters {
    [Serializable]
	public class Character : IActor
    {
        [Header("Infos")]
        [SerializeField]
        private string name;

        [SerializeField]
        private Sprite picture;


        public string Name => name;

        public Sprite Picture => picture;

        public override string ToString()
        {
            return name;
        }


        #region Temp
        [Header("Temp")]
        [SerializeField]
        private float speed = 1;

        public float Speed => speed;
        #endregion
    }
}