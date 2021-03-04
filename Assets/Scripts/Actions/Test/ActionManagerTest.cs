using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hexaplex.Actions;
using System;

namespace Hexaplex {
	public class ActionManagerTest : MonoBehaviour
    {
        private void Start()
        {
            /*TestActions.TestCoroutine(1)
                .OnSuccess(() => Debug.Log("Coroutine Success"))
                .Enqueue();

            TestActions.TestInstant("A wonderful first test").Enqueue();
            TestActions.TestCoroutine(3).Enqueue();
            TestActions.TestInstant("A wonderful second test").Enqueue();
            TestActions.TestInstant("A wonderful third test but called first").Execute();*/

            /*GameAction action = TestActions.TestInstantWithError(new Exception("Test Exception"))
                .OnFailure((e) => Debug.Log("An error occured as expected: " + e))
                .OnSuccess(() => Debug.LogError("An error should have occured..."));*/

            /*TestActions.TestInstant("A wonderful first test").Enqueue();
            GeneralActions.Wait(1).Enqueue();

            GroupAction.Create("My first group action",
                GeneralActions.Wait(3),
                GroupAction.Create("Inner group action",
                    GeneralActions.Wait(3),
                    TestActions.TestInstant("A wonderful Inner test")
                ),
                TestActions.TestInstant("A wonderful second test")
            ).Enqueue();

            TestActions.TestInstant("A wonderful third test").Enqueue();
            GeneralActions.Wait(2).Enqueue();*/

            TestActions.TestCoroutineWithError(3, new Exception("Coroutine Error"))
                .OnFailure(e => Debug.Log("Yay! the error has been caught: " + e))
                .OnSuccess(() => Debug.LogError("An error should have occured..."))
                .Enqueue();

            GroupAction.Create("Group action with failure inside",
                TestActions.TestInstantWithError(new Exception("Test Exception"))
                    .OnFailure((e) => Debug.Log("An error occured as expected: " + e))
                    .OnSuccess(() => Debug.LogError("An error should have occured...")),
                TestActions.TestCoroutineWithError(3, new Exception("Coroutine Error"))
                    .OnFailure(e => Debug.Log("Yay! the error has been caught: " + e))
                    .OnSuccess(() => Debug.LogError("An error should have occured..."))
                    .StopOnError(true)
                )
                .Enqueue();
            

            TestActions.TestInstantWithError(new Exception("Should not be called Exception"))
                .OnFailure((e) => Debug.Log("An error occured as expected: " + e))
                .OnSuccess(() => Debug.LogError("An error should have occured..."))
                .Enqueue();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Press");
                TestActions.TestInstantWithError(new Exception("This exception won't break anything..."))
                    .OnFailure(e => Debug.Log(e.Message + "and was caught!"))
                    .Execute();
            }
        }
    }
}