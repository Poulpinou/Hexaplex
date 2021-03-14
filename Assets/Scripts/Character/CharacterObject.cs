using UnityEngine;

namespace Hexaplex.Characters {
    [CreateAssetMenu(menuName = "Hexaplex/Character/CharacterObject")]
	public class CharacterObject : ScriptableObject
    {
        [SerializeField]
        private Character character;

        public Character Character => character;
    }
}