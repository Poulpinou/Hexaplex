using UnityEngine;

namespace Hexaplex {
	public enum Direction
    {
       North,
       East,
       South,
       West
    }

    public static class DirectionExtensions
    {
        public static Vector2Int GetCoefficient(this Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return Vector2Int.up;
                case Direction.East:
                    return Vector2Int.right;
                case Direction.South:
                    return Vector2Int.down;
                case Direction.West:
                    return Vector2Int.left;
            }
            return Vector2Int.zero;
        }
    }
}