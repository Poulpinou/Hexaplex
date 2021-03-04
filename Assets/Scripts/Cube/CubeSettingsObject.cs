using UnityEngine;

namespace Hexaplex.Cube {
    /// <summary>
    /// This class is just a <see cref="ScriptableObject"/> that holds <see cref="CubeSettings"/>
    /// </summary>
    [CreateAssetMenu(menuName = "Hexaplex/Cube/Settings")]
	public class CubeSettingsObject : ScriptableObject
    {
        [SerializeField]
        private CubeSettings settings;

        public CubeSettings Settings => settings;
    }
}