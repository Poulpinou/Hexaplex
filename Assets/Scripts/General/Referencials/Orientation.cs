using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex {
	public enum Orientation
    {
        Top,
        Down,
        Front,
        Back,
        Left,
        Right
    }

    public static class OrientationHelper
    {
        public static Vector3Int GetCoefficient(this Orientation orientation) {
            switch (orientation)
            {
                case Orientation.Top:
                    return Vector3Int.up;
                case Orientation.Down:
                    return Vector3Int.down;
                case Orientation.Front:
                    return new Vector3Int(0, 0, -1);
                case Orientation.Back:
                    return new Vector3Int(0, 0, 1);
                case Orientation.Left:
                    return Vector3Int.left;
                case Orientation.Right:
                    return Vector3Int.right;
            }
            return Vector3Int.zero;
        }

        public static int ExtractCoeffValue(this Orientation orientation, Vector3Int position)
        {
            switch (orientation)
            {
                case Orientation.Top:
                case Orientation.Down:
                    return position.y;
                case Orientation.Front:
                case Orientation.Back:
                    return position.z;
                case Orientation.Left:
                case Orientation.Right:
                    return position.x;
            }
            return 0;
        }

        public static Vector3 GetRotation(this Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Top:
                    return Vector3.zero;
                case Orientation.Down:
                    return new Vector3(0, 0, 180);
                case Orientation.Front:
                    return new Vector3(-90, 0, 0);
                case Orientation.Back:
                    return new Vector3(90, 0, 0);
                case Orientation.Left:
                    return new Vector3(0, 0, 90);
                case Orientation.Right:
                    return new Vector3(0, 0, -90);
            }
            return Vector3.zero;
        }
    }
}