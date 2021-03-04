using UnityEngine;
using UnityEngine.Events;
using System;

namespace Hexaplex.Cube {
    /// <summary>
    /// This class holds every <see cref="Cube"/> related events and exposes static accessors
    /// in order to use them.
    /// </summary>
	public class CubeEvents : StaticManager<CubeEvents>
    {
        #region Events
        [Serializable]
        public class CubeEvent : UnityEvent<Cube> { }

        [Serializable]
        public class GridCellEvent : UnityEvent<CubeGridCell> { }
        #endregion


        #region Fields
        [SerializeField]
        private CubeEvent onCubeBuilt = new CubeEvent();

        [SerializeField]
        private GridCellEvent onCellClick = new GridCellEvent();
        #endregion


        #region Properties
        /// <summary>
        /// This event is called when the main <see cref="Cube"/> has been built
        /// </summary>
        public static CubeEvent OnCubeBuilt => Instance.onCubeBuilt;

        /// <summary>
        /// This event is called when a <see cref="CubeGridCell"/> has been clicked
        /// </summary>
        public static GridCellEvent OnCellClick => Instance.onCellClick; 
        #endregion
    }
}