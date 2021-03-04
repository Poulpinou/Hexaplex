using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Hexaplex.Cube {
    /// <summary>
    /// This object represents the position and the orientation of a
    /// tile in a <see cref="Cube"/>
    /// </summary>
    [Serializable]
	public struct Cubxel
    {
        [SerializeField]
        [Tooltip("The 3D grid position in the Cube")]
        private Vector3Int position;

        [SerializeField]
        [Tooltip("The side of the cube")]
        private Orientation orientation;


        /// <summary>
        /// The 3D grid position in the Cube
        /// </summary>
        public Vector3Int Position => position;

        /// <summary>
        /// The side of the cube
        /// </summary>
        public Orientation Orientation => orientation;


        public Cubxel(Vector3Int position, Orientation orientation)
        {
            this.position = position;
            this.orientation = orientation;
        }


        /// <summary>
        /// Returns every possible cubxels from a position. (count: 1 for a face, 2 for an edge and 3 for a corner) 
        /// </summary>
        /// <param name="position">The 3D grid position in the Cube</param>
        /// <param name="max">The size of the <see cref="Cube"/></param>
        /// <returns>A list of cubxels</returns>
        public static List<Cubxel> GetPossibleCubxels(Vector3Int position, int max)
        {
            return Enum.GetValues(typeof(Orientation))
               .Cast<Orientation>()
               .Where(orientation => {
                   int coeffDirection = orientation.ExtractCoeffValue(orientation.GetCoefficient());
                   if (coeffDirection > 0)
                   {
                       return orientation.ExtractCoeffValue(position) == max - 1;
                   }else if (coeffDirection < 0)
                   {
                       return orientation.ExtractCoeffValue(position) == 0;
                   }
                   return false;
               })
               .Select(orientation => new Cubxel(position, orientation))
               .ToList();
        }

        /// <summary>
        /// Gets the world position of the cubxel on the current <see cref="Cube"/>
        /// </summary>
        /// <returns>The world position of this <see cref="Cubxel"/></returns>
        public Vector3 GetWorldPosition()
        {
            return GetWorldPosition(Cube.Current);
        }

        /// <summary>
        /// Gets the world position of the cubxel on the provided <see cref="Cube"/>
        /// </summary>
        /// <param name="cube">The reference Cube</param>
        /// <returns>The world position of this <see cref="Cubxel"/></returns>
        public Vector3 GetWorldPosition(Cube cube)
        {
            return cube.transform.position + position + (0.5f * (Vector3)orientation.GetCoefficient());
        }

        /// <summary>
        /// Gets the world eulerAngles of the cubxel on the current <see cref="Cube"/>
        /// </summary>
        /// <returns>The world eulerAngles of this <see cref="Cubxel"/></returns>
        public Vector3 GetWorldEulerAngles()
        {
            return GetWorldEulerAngles(Cube.Current);
        }

        /// <summary>
        /// Gets the world eulerAngles of the cubxel on the provided <see cref="Cube"/>
        /// </summary>
        /// <param name="cube">The reference Cube</param>
        /// <returns>The world eulerAngles of this <see cref="Cubxel"/></returns>
        public Vector3 GetWorldEulerAngles(Cube cube)
        {
            return cube.transform.eulerAngles + orientation.GetRotation();
        }

        public override string ToString()
        {
            return string.Format("[{0}:[{1},{2},{3}]]", Orientation, Position.x, Position.y, Position.z);
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Cubxel))
            {
                return false;
            }
            Cubxel other = (Cubxel) obj;
            return Position.Equals(other.position) && orientation.Equals(other.orientation);
        }


        public static bool operator ==(Cubxel a, Cubxel b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Cubxel a, Cubxel b)
        {
            return a != b;
        }
    }
}