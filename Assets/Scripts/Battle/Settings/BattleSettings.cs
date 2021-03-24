using UnityEngine;

namespace Hexaplex.Battles {
    [CreateAssetMenu(menuName ="Hexaplex/Battle/Settings")]
	public class BattleSettings : ScriptableObject
    {
        #region Fields
        [Header("Queue")]
        [SerializeField]
        private int queueLength = 10;


        [Header("Colors")]
        [SerializeField]
        private Color selfColor = Color.blue;

        [SerializeField]
        private Color allyColor = Color.green;

        [SerializeField]
        private Color neutralColor = Color.yellow;

        [SerializeField]
        private Color enemyColor = Color.red;
        #endregion

        #region Properties
        // Queue
        public int QueueLength => queueLength;

        // Colors
        public Color SelfColor => selfColor;
        public Color AllyColor => allyColor;
        public Color NeutralColor => neutralColor;
        public Color EnemyColor => enemyColor; 
        #endregion
    }
}