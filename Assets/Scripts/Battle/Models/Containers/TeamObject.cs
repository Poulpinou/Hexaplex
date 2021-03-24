using UnityEngine;

namespace Hexaplex.Battles {
    [CreateAssetMenu(menuName = "Hexaplex/Battle/Team")]
	public class TeamObject : ScriptableObject
    {
        [SerializeField]
        private ITeam team;

        public ITeam Team => team;
    }
}