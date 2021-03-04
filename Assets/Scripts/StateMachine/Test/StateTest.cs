using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexaplex.StateMachine {
	public class StateTest : MonoBehaviour
    {
        public class TestState : State
        {
            public readonly int order;

            public readonly bool reversable;


            public override bool Reversable => reversable;


            public TestState(int order, bool reversable = false)
            {
                this.order = order;
                this.reversable = reversable;
            }

            public TestState() => new TestState(0, false);


            protected override void OnEnter()
            {
                Debug.LogFormat("Entering in State #{0}", order);
            }

            protected override void OnExit()
            {
                Debug.LogFormat("Exiting State #{0}", order);
            }
        }

        [SerializeField]
        private StateMachine stateMachine;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TestState current = stateMachine.CurrentState as TestState;
                stateMachine.ChangeState(new TestState(current == null ? 0 : current.order + 1, Input.GetKey(KeyCode.LeftControl)));
            }

            if (Input.GetMouseButtonDown(1))
            {
                stateMachine.PreviousState();
            }
        }
    }
}