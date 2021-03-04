using UnityEngine;
using System;

namespace Hexaplex.Cube {
    /// <summary>
    /// This object defines the aspect of a <see cref="Cube"/>
    /// </summary>
    [CreateAssetMenu(menuName ="Hexaplex/Cube/Theme")]
	public class CubeTheme : ScriptableObject
    {
        [Header("Parts")]
        [SerializeField]
        [Tooltip("Every tiles that can be used by the Cube")]
        private CubeTile[] tiles;

        [SerializeField]
        [Tooltip("The model of the cells the Cube will use")]
        private CubeGridCell cellModel;


        /// <summary>
        /// The model of the cells the Cube will use
        /// </summary>
        public CubeGridCell CellModel => cellModel;


        /// <summary>
        /// Returns a random tile from the provided tile list
        /// </summary>
        /// <returns>A <see cref="CubeTile"/></returns>
        public CubeTile GetRandomTile()
        {
            if(tiles.Length == 0)
            {
                throw new Exception(string.Format("No tiles provided in {0} theme", name));
            }

            return tiles[UnityEngine.Random.Range(0, tiles.Length)];
        }
    }
}