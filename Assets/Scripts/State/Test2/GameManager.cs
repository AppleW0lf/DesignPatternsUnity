using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.State.Test2
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerController player;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                player.ChangeState(new IdleState());
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                player.ChangeState(new WalkingState());
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                player.ChangeState(new JumpingState());
            }
        }
    }
}