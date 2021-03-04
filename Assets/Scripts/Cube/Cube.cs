using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Hexaplex.Cube {
    /// <summary>
    /// This is the main cube object. Only one is allowed per scene
    /// </summary>
	public class Cube : MonoBehaviour
    {
        #region Fields
        [Header("Settings")]
        [SerializeField]
        [Tooltip("You can create your own cube settings from the creation menu")]
        private CubeSettingsObject cubeSettings;

        [SerializeField]
        [Tooltip("If set to true, the cube will build on awake")]
        private bool buildOnAwake = true;


        [Header("Containers")]
        [SerializeField]
        [Tooltip("The parent of every CubeBlocks")]
        private Transform blocksContainer;

        [SerializeField]
        [Tooltip("The parent of every CubeGrid")]
        private Transform gridsContainer;

        [SerializeField]
        [Tooltip("The parent of every object attached to the cube")]
        private Transform objectsContainer;


        private CubeBlock[,,] blocks;
        private Dictionary<Orientation, CubeGrid> grids;
        #endregion

        #region Properties
        /// <summary>
        /// The active scene's Cube
        /// </summary>
        public static Cube Current { get; set; }

        /// <summary>
        /// The current <see cref="CubeSettings"/> of the Cube
        /// </summary>
        public CubeSettings Settings { get; private set; }

        /// <summary>
        /// The size of the cube (its dimensions are size*size*size)
        /// </summary>
        public int Size => Settings.Size;

        /// <summary>
        /// The parent of every <see cref="CubeBlock"/>
        /// </summary>
        public Transform BlocksContainer => blocksContainer;

        /// <summary>
        /// The parent of every <see cref="CubeGrid"/>
        /// </summary>
        public Transform GridsContainer => gridsContainer;

        /// <summary>
        /// The center position of the cube
        /// </summary>
        public Vector3 Center => transform.position + Vector3.one * (Size / 2);

        /// <summary>
        /// True if Cube has been built
        /// </summary>
        public bool Built { get; private set; } = false;
        #endregion

        #region Methods
        /// <summary>
        /// Gets the <see cref="CubeTile"/> which is associated to provided <see cref="Cubxel"/>
        /// </summary>
        /// <param name="cubxel">The cube position of the desired tile</param>
        /// <returns>A <see cref="CubeTile"/> or null</returns>
        public CubeTile GetTile(Cubxel cubxel)
        {
            return GetBlock(cubxel)?.GetTile(cubxel.Orientation);
        }

        /// <summary>
        /// Gets the <see cref="CubeBlock"/> which is associated to provided <see cref="Cubxel"/>
        /// </summary>
        /// <param name="cubxel">The cube position of the desired block</param>
        /// <returns>A <see cref="CubeBlock"/> or null</returns>
        public CubeBlock GetBlock(Cubxel cubxel)
        {
            return GetBlock(cubxel.Position);
        }

        /// <summary>
        /// Gets the <see cref="CubeBlock"/> which is associated to provided position
        /// </summary>
        /// <param name="position">The position of the desired block</param>
        /// <returns>A <see cref="CubeBlock"/> or null</returns>
        public CubeBlock GetBlock(Vector3Int position)
        {
            return blocks[position.x, position.y, position.z];
        }

        /// <summary>
        /// Builds the cube from its <see cref="CubeSettings"/>
        /// </summary>
        /// <returns>Self</returns>
        public Cube Build()
        {
            if (Built)
            {
                throw new Exception("The Cube has been built already");
            }

            name = Settings.Name;

            // Build Blocks
            blocks = new CubeBlock[Size, Size, Size];
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    for (int z = 0; z < Size; z++)
                    {
                        // Check if at least one is on the side
                        if (x == 0 || y == 0 || z == 0 || x == Size - 1 || y == Size - 1 || z == Size - 1)
                        {
                            blocks[x, y, z] = CubeBlock.Create(this, new Vector3Int(x, y, z));
                        }
                    }
                }
            }

            // Build Grids
            grids = GridsContainer.GetComponentsInChildren<CubeGrid>()
                .GroupBy(grid => grid.Orientation)
                .ToDictionary(group => group.Key, group => group.First());

            if(grids.Count != 6)
            {
                throw new Exception(string.Format("Invalid amount of grid found: {0}/6", grids.Count));
            }

            foreach (CubeGrid grid in grids.Values)
            {
                grid.Build(this);
            }

            Built = true;

            CubeEvents.OnCubeBuilt.Invoke(this);

            return this;
        }
        #endregion

        #region Runtime Methods
        private void Awake()
        {
            if (Current)
            {
                throw new Exception("Another cube exist in the scene, this is not allowed");
            }
            Settings = cubeSettings.Settings;
            Current = this;

            if (buildOnAwake)
            {
                Build();
            }
        } 
        #endregion
    }
}