using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.State.Test2
{
    public class WalkingState : IPlayerState
    {
        public void EnterState(PlayerController player)
        {
            Debug.Log("Entering Walking State");
        }

        public void UpdateState(PlayerController player)
        {
            Debug.Log("Walking State Update");
            // Logic for walking state update
        }

        public void ExitState(PlayerController player)
        {
            Debug.Log("Exiting Walking State");
        }
    }
}