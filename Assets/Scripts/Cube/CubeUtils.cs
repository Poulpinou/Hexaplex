using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.Cube {
    public static class CubeUtils
    {

        #region Transform Extensions
        public static void SetToCubxel(this Transform transform, Cubxel cubxel)
        {
            transform.position = cubxel.GetWorldPosition();
            transform.eulerAngles = cubxel.GetWorldEulerAngles();
        } 
        #endregion

    }
}