using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.State.GoodExample
{
    public static class InputManager
    {
        public static event System.Action OnMove;

        public static event System.Action OnJump;

        public static event System.Action OnCrouch;

        public static event System.Action OnAttack;

        public static event System.Action OnDefend;

        public static event System.Action OnSlide;

        public static event System.Action OnClimb;

        public static event System.Action OnSwim;

        public static event System.Action OnFly;

        public static event System.Action OnDash;

        public static void Update()
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                OnMove?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump?.Invoke();
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                OnCrouch?.Invoke();
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                OnAttack?.Invoke();
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                OnDefend?.Invoke();
            }
            if (Input.GetKey(KeyCode.C))
            {
                OnSlide?.Invoke();
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                OnClimb?.Invoke();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                OnSwim?.Invoke();
            }
            if (Input.GetKey(KeyCode.F))
            {
                OnFly?.Invoke();
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                OnDash?.Invoke();
            }
        }
    }
}