using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex {
	public static class Vector2IntExtensions
    {
        /// <summary>
        /// True if Vector has its values between min(inclusive) and max(exclusive)
        /// </summary>
        public static bool HasValuesBetween(this Vector2Int vector, int min, int max)
        {
            return vector.x >= min && vector.y >= min && vector.x < max && vector.y < max;
        }
    }
}