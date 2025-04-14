using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.State.Test2
{
    public class JumpingState : IPlayerState
    {
        public void EnterState(PlayerController player)
        {
            Debug.Log("Entering Jumping State");
        }

        public void UpdateState(PlayerController player)
        {
            Debug.Log("Jumping State Update");
            // Logic for jumping state update
        }

        public void ExitState(PlayerController player)
        {
            Debug.Log("Exiting Jumping State");
        }
    }
}