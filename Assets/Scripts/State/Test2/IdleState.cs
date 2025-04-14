using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.State.Test2
{
    public class IdleState : IPlayerState
    {
        public void EnterState(PlayerController player)
        {
            Debug.Log("Entering Idle State");
        }

        public void UpdateState(PlayerController player)
        {
            Debug.Log("Idle State Update");
            // Logic for idle state update
        }

        public void ExitState(PlayerController player)
        {
            Debug.Log("Exiting Idle State");
        }
    }
}