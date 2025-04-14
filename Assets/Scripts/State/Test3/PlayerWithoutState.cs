using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.State.Test3
{
    public class PlayerWithoutState : MonoBehaviour
    {
        public float walkSpeed = 10f;
        public float runSpeed = 20f;

        private enum State
        {
            Idle,
            Walk,
            Run
        }

        private State _currentState = State.Idle;
        private float _currentSpeed; // Текущая скорость движения

        private void Start()
        {
            _currentSpeed = walkSpeed; // Начальная скорость
        }

        private void Update()
        {
            // Обработка ввода
            float inputHorizontal = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");
            Vector2 inputDirection = new Vector2(inputHorizontal, inputVertical);

            // Обработка смены состояния
            if (inputDirection.sqrMagnitude > 0f)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    _currentState = State.Run;
                    _currentSpeed = runSpeed;
                }
                else
                {
                    _currentState = State.Walk;
                    _currentSpeed = walkSpeed;
                }
            }
            else
            {
                _currentState = State.Idle;
            }

            // Действия в зависимости от состояния
            switch (_currentState)
            {
                case State.Idle:
                    Debug.LogWarning("Idle");
                    break;

                case State.Walk:
                    Move(inputDirection);
                    break;

                case State.Run:
                    Move(inputDirection);
                    break;
            }
        }

        private void Move(Vector2 inputDirection)
        {
            transform.position += new Vector3(inputDirection.x, inputDirection.y, 0f) * (_currentSpeed * Time.deltaTime);
        }
    }
}