using System.Collections;
using UnityEngine;

namespace Hexaplex.Actions {
	public static class GeneralActions
    {
        #region Actions
        public static GameAction Wait(float duration) => CoroutineAction.Create(string.Format("Waiting for {0}sec", duration), () => RunWait(duration));
        #endregion

        #region Coroutines
        private static IEnumerator RunWait(float duration)
        {
            yield return new WaitForSeconds(duration);
        }
        #endregion
    }
}