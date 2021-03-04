using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Cube
{
    /// <summary>
    /// This abstract object makes the link between <see cref="Cubxel"/>s and
    /// <see cref="CubeTile"/>s. It has a 3DInt position and has up to 3 tiles
    /// as children.
    /// </summary>
    public class CubeBlock : MonoBehaviour
    {
        private Dictionary<Orientation, CubeTile> tiles;


        /// <summary>
        /// The 3D grid position of the block.
        /// </summary>
        public Vector3Int Position { get; private set; }


        /// <summary>
        /// Creates a block for the provided <see cref="Cube"/> at the provided
        /// 3D grid position.
        /// </summary>
        /// <param name="cube">The parent cube</param>
        /// <param name="position">The 3D grid position</param>
        /// <returns>Self</returns>
        public static CubeBlock Create(Cube cube, Vector3Int position)
        {
            // Create Object
            GameObject obj = new GameObject();
            CubeBlock cubeBlock = obj.AddComponent<CubeBlock>();
            cubeBlock.Position = position;
            cubeBlock.name = string.Format("block_x{0}_y{1}_z{2}", position.x, position.y, position.z);
            cubeBlock.transform.parent = cube.BlocksContainer;
            cubeBlock.transform.localPosition = position;

            // Create Tiles
            cubeBlock.tiles = new Dictionary<Orientation, CubeTile>();
            Cubxel.GetPossibleCubxels(position, cube.Size)
                .ForEach(cubxel =>
                {
                    CubeTile tile = Instantiate(cube.Settings.Theme.GetRandomTile(), cubeBlock.transform)
                        .Build(cubeBlock, cubxel);
                    cubeBlock.tiles.Add(cubxel.Orientation, tile);
                });

            return cubeBlock;
        }

        /// <summary>
        /// Gets a <see cref="CubeTile"/> from provided <see cref="Orientation"/>. The 
        /// block may not have the desired tile in its children.
        /// </summary>
        /// <param name="orientation">The orientation of the tile</param>
        /// <returns>The associated <see cref="CubeTile"/> or null</returns>
        public CubeTile GetTile(Orientation orientation)
        {
            if (tiles.ContainsKey(orientation))
            {
                return tiles[orientation];
            }
            return null;
        }
    }
}