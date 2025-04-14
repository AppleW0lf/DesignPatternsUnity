using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.State.Test2
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayerState currentState;

        private void Start()
        {
            // Initialize player with Idle state
            ChangeState(new IdleState());
        }

        public void ChangeState(IPlayerState newState)
        {
            if (currentState != null)
                currentState.ExitState(this);

            currentState = newState;
            currentState.EnterState(this);
        }

        private void Update()
        {
            if (currentState != null)
                currentState.UpdateState(this);
        }
    }
}