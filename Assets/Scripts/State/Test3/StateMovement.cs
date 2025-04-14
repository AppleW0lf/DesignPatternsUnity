using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.State.Test3
{
    public class StateMovement : State
    {
        protected readonly float Speed;

        public StateMovement(StateMachine stateMachine, float speed) : base(stateMachine)
        {
            Speed = speed;
        }

        public override void Enter()
        {
            Debug.LogWarning($"Movement ({this.GetType().Name}) State [Enter]");
        }

        public override void Update(Transform transform)
        {
            var inputDirection = ReadInput();
            if (inputDirection.sqrMagnitude == 0f)
            {
                stateMachine.SetState<StateIdle>();
            }
            Move(transform, inputDirection);
        }

        protected Vector2 ReadInput()
        {
            var inputHorizontal = Input.GetAxis("Horizontal");
            var inputVertical = Input.GetAxis("Vertical");
            var inputDirection = new Vector2(inputHorizontal, inputVertical);
            return inputDirection;
        }

        protected virtual void Move(Transform transform, Vector2 inputDirection)
        {
            transform.position += new Vector3(inputDirection.x, inputDirection.y, 0f) * (Speed * Time.deltaTime);
        }
    }
}