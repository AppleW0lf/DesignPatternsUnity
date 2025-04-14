using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.State.GoodExample
{
    using UnityEngine;

    public class DashingState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.GetSpriteRenderer().color = new Color(0.5f, 0, 1); // Цвет для состояния Dashing
        }

        public void Update(Player player)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                player.TransitionTo(new IdleState());
            }
        }

        public void Exit(Player player)
        { }
    }
}