using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.State.Test3
{
    public class PlayerWithStateController : MonoBehaviour
    {
        private StateMachine _stateMachine;

        [SerializeField]
        private float _walkSpeed = 10f;

        [SerializeField]
        private float _runSpeed = 20f;

        private void Start()
        {
            _stateMachine = new();
            _stateMachine.AddState(new StateIdle(_stateMachine));
            _stateMachine.AddState(new StateWalk(_stateMachine, _walkSpeed));
            _stateMachine.AddState(new StateRun(_stateMachine, _runSpeed));

            _stateMachine.SetState<StateIdle>();
        }

        private void Update()
        {
            _stateMachine.Update(transform);
        }
    }
}