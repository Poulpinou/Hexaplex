using UnityEngine;
using System;

namespace Hexaplex.Cube {
    /// <summary>
    /// This class hold many setting that defines the behaviour and the 
    /// structure of a <see cref="Cube"/>
    /// </summary>
    [Serializable]
	public class CubeSettings
    {
        [Header("Settings")]
        [SerializeField]
        [Tooltip("The name of the cube gameobject")]
        private string name = "Cube";

        [SerializeField]
        [Range(4, 16)]
        [Tooltip("The size of the cube")]
        private int size = 4;

        [SerializeField]
        [Tooltip("You can create your own cube theme from the creation menu")]
        private CubeTheme theme;


        public CubeTheme Theme => theme;
        public string Name => name;
        public int Size => size;
    }
}