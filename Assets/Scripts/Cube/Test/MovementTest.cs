using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Cube.Test {
    public class MovementTest : MonoBehaviour
    {
        public enum Mode
        {
            PlaceOnCubxel,
            MoveForward
        }

        [SerializeField]
        private Mode mode;

        [SerializeField]
        private Cubxel cubxel;

        [SerializeField]
        private Direction direction;


        private Cubxel currentPos;


        public Cubxel Target { get; set; }


        public Cubxel Cubxel {
            get => cubxel;
            set
            {
                cubxel = value;
                transform.SetToCubxel(cubxel);
            }
        }

        private void MoveForward()
        {

        }


        private void Update()
        {
            if(mode == Mode.MoveForward)
            {
                MoveForward();
            }
        }
    }
}