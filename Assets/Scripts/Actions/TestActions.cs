using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hexaplex.Actions {
	public static class TestActions
    {
        public static GameAction TestInstant(string message) =>
            InstantAction
                .Create("Test Instant", () => Debug.Log("Instant Action: " + message));

        public static GameAction TestInstantWithError(Exception error) =>
            InstantAction
                .Create("Test Instant With Error", () => throw error);

        public static GameAction TestCoroutine(int duration) =>
            CoroutineAction
                .Create("Test Coroutine", () => TestCoroutineMethod(duration));

        public static GameAction TestCoroutineWithError(int duration, Exception error) =>
            CoroutineAction
                .Create("Test Coroutine With Error", () => TestCoroutineMethod(duration, error));


        private static IEnumerator TestCoroutineMethod(int duration, Exception testError = null)
        {
            Debug.LogFormat("Will wait {0} sec {1}", duration, testError != null ? "and fail" : "");

            for (int i = 0; i < duration; i++)
            {
                yield return new WaitForSeconds(1);
                Debug.LogFormat("Waited for {0} sec...", i + 1);
            }

            if(testError != null)
            {
                Debug.LogFormat("Sending test error...");
                throw testError;
            }
        }
    }
}