using UnityEngine;

namespace Assets.Scripts.State.Test3
{
    public class StateWalk : StateMovement
    {
        public StateWalk(StateMachine stateMachine, float speed) : base(stateMachine, speed)
        {
        }

        public override void Update(Transform transform)
        {
            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                stateMachine.SetState<StateIdle>();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                stateMachine.SetState<StateRun>();
            }
            Move(transform, inputDirection);
        }
    }
}