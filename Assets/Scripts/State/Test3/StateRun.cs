using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.State.Test3
{
    public class StateRun : StateMovement
    {
        public StateRun(StateMachine stateMachine, float speed) : base(stateMachine, speed)
        {
        }

        public override void Update(Transform transform)
        {
            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                stateMachine.SetState<StateIdle>();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                stateMachine.SetState<StateWalk>();
            }
            Move(transform, inputDirection);
        }
    }
}