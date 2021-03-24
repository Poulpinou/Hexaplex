using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Battles {
    [CreateAssetMenu(menuName = "Hexaplex/Battle/ComputerOpponent")]
    public class ComputerOpponent : ScriptableObject, IParticipant
    {
        [SerializeField]
        private string displayName;

        [SerializeField]
        private Sprite picture;

        [SerializeField]
        private ControllerType controllerType = ControllerType.AI;


        public string Name => name;

        public Sprite Picture => picture;

        public ControllerType ControllerType => controllerType;
    }
}