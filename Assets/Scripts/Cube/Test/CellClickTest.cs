using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Cube.Test {
	public class CellClickTest : MonoBehaviour
    {
        public enum TestAction
        {
            DestroyOnClick,
            SetPositionOnClick
        }

        [SerializeField]
        private TestAction action;

        [SerializeField]
        private MovementTest movementTest;

        private void DestroyClickedCell(CubeGridCell cell)
        {
            CubeTile tile = Cube.Current.GetTile(cell.Cubxel);
            if (tile)
            {
                Destroy(tile.gameObject);
            }
            else
            {
                Debug.Log("Tile not found:" + cell.Cubxel.ToString());
            }
            
        }

        private void OnCellClick(CubeGridCell cell)
        {
            switch (action)
            {
                case TestAction.DestroyOnClick:
                    DestroyClickedCell(cell);
                    break;
                case TestAction.SetPositionOnClick:
                    movementTest.Cubxel = cell.Cubxel;
                    break;
            }
        }

        private void Start()
        {
            CubeEvents.OnCellClick.AddListener(OnCellClick);
        }
    }
}