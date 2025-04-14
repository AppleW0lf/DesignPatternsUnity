using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.State.GoodExample
{
    using UnityEngine;

    public class CrouchingState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.GetSpriteRenderer().color = Color.yellow; // Цвет для состояния Crouching
        }

        public void Update(Player player)
        {
            if (!Input.GetKey(KeyCode.LeftControl))
            {
                player.TransitionTo(new IdleState());
            }
        }

        public void Exit(Player player)
        { }
    }
}