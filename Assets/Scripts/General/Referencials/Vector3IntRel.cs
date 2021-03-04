using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hexaplex
{
    [Serializable]
    public struct Vector3IntRel
    {
        public enum RelativeValue
        {
            VarX,
            VarY,
            VarZ,
            InverseVarX,
            InverseVarY,
            InverseVarZ,
            Zero,
            Min,
            Max
        }


        [SerializeField]
        private RelativeValue x;

        [SerializeField]
        private RelativeValue y;

        [SerializeField]
        private RelativeValue z;


        public RelativeValue X => x;
        public RelativeValue Y => y;
        public RelativeValue Z => z;


        public Vector3IntRel(RelativeValue x, RelativeValue y, RelativeValue z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3Int Convert(Vector3Int input, int min = 0, int max = int.MaxValue)
        {
            return new Vector3Int(
                    GetValue(x, input, min, max),
                    GetValue(y, input, min, max),
                    GetValue(z, input, min, max)
                );
        }

        public static int GetValue(RelativeValue relativeValue, Vector3Int input, int min = 0, int max = int.MaxValue)
        {
            switch (relativeValue)
            {
                case RelativeValue.VarX: return input.x;
                case RelativeValue.VarY: return input.y;
                case RelativeValue.VarZ: return input.z;
                case RelativeValue.InverseVarX: return max - input.x;
                case RelativeValue.InverseVarY: return max - input.y;
                case RelativeValue.InverseVarZ: return max - input.z;
                case RelativeValue.Zero: return 0;
                case RelativeValue.Min: return min;
                case RelativeValue.Max: return max;
            }
            return 0;
        }
    }
}