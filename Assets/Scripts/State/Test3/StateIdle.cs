using UnityEngine;

namespace Assets.Scripts.State.Test3
{
    public class StateIdle : State
    {
        public StateIdle(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.LogWarning("Idle State [Enter]");
        }

        public override void Exit()
        {
            Debug.LogWarning("Idle State [Exit]");
        }

        public override void Update(Transform transform)
        {
            if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
            {
                stateMachine.SetState<StateWalk>();
            }
        }
    }
}