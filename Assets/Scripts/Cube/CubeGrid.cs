using UnityEngine;
using UnityEngine.UI;
using System;

namespace Hexaplex.Cube {
    /// <summary>
    /// The purpose of this object is to order its <see cref="CubeGridCell"/> in a grid,
    /// and to make the <see cref="Canvas"/> fit the <see cref="Cube"/> face.
    /// </summary>
	public class CubeGrid : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        [Tooltip("The side of the cube to cover. Only one grid is detected per side")]
        private Orientation orientation;

        [SerializeField]
        [Tooltip("Represents the transformations that should be made to place the canvas on the side of the Cube")]
        private Vector3IntRel relativePosition;

        [SerializeField]
        [Tooltip("Represents the way we can transform the local grid coordinates to 3D grid coordinates")]
        private Vector3IntRel gridToWorld;


        [Header("Relations")]
        [SerializeField]
        [Tooltip("The Canvas that holds the tiles")]
        private Canvas canvas;

        [SerializeField]
        [Tooltip("The layout for the tiles")]
        private GridLayoutGroup gridLayout;


        private CubeGridCell[,] cells;


        /// <summary>
        /// The side of the cube to cover. Only one grid is detected per side
        /// </summary>
        public Orientation Orientation => orientation;

        /// <summary>
        /// True if the grid has been built
        /// </summary>
        public bool Built { get; private set; }


        /// <summary>
        /// Builds the grid.
        /// </summary>
        /// <param name="cube">The <see cref="Cube"/> that owns the grid</param>
        /// <returns>Self</returns>
        public CubeGrid Build(Cube cube)
        {
            if (Built)
            {
                throw new Exception("The grid has been built already");
            }

            // Configure Canvas
            RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
            canvasRectTransform.sizeDelta = Vector2.one * cube.Size;
            canvas.worldCamera = Camera.main;
            canvas.transform.localPosition = relativePosition.Convert(Vector3Int.zero, max: cube.Size) - (Vector3.one / 2);

            // Configure layout
            gridLayout.constraintCount = cube.Size;

            // Create cells
            cells = new CubeGridCell[cube.Size, cube.Size];
            for (int x = 0; x < cube.Size; x++)
            {
                for (int y = 0; y < cube.Size; y++)
                {
                    Cubxel cubxel = new Cubxel(gridToWorld.Convert(new Vector3Int(x, y, 0), max: cube.Size - 1), Orientation);
                    cells[x, y] = Instantiate(cube.Settings.Theme.CellModel, gridLayout.transform).Build(cubxel);
                }
            }

            Built = true;

            return this;
        }


        private void OnValidate()
        {
            name = string.Format("grid_{0}", orientation);
        }
    }
}