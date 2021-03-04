using UnityEngine;

namespace Hexaplex.Cube {
    /// <summary>
    /// A tile of a <see cref="Cube"/>. Its position is defined by a <see cref="Cubxel"/>
    /// </summary>
	public class CubeTile : MonoBehaviour
    {
        /// <summary>
        /// The cube position of the tile
        /// </summary>
        public Cubxel Cubxel { get; private set; }

        /// <summary>
        /// The block that hold the tile
        /// </summary>
        public CubeBlock Block { get; private set; }

        /// <summary>
        /// True if the tile has been built
        /// </summary>
        public bool Built { get; private set; }


        /// <summary>
        /// Builds the tile
        /// </summary>
        /// <param name="block">The block that holds the tile</param>
        /// <param name="cubxel">The cube position of the tile</param>
        /// <returns>Self</returns>
        public CubeTile Build(CubeBlock block, Cubxel cubxel)
        {
            Cubxel = cubxel;
            Block = block;

            transform.parent = block.transform;
            transform.localPosition = ((Vector3) cubxel.Orientation.GetCoefficient()) * 0.5f;
            transform.localEulerAngles = cubxel.Orientation.GetRotation();
            name = string.Format("tile_o{0}_x{1}_y{2}_z{3}", cubxel.Orientation, cubxel.Position.x, cubxel.Position.y, cubxel.Position.z);

            return this;
        }
    }
}