using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.State.GoodExample
{
    using UnityEngine;

    public class JumpingState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.GetSpriteRenderer().color = Color.red; // Цвет для состояния Jumping
            player.GetRigidbody().AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }

        public void Update(Player player)
        {
            if (player.GetRigidbody().linearVelocity.y == 0)
            {
                player.TransitionTo(new IdleState());
            }
        }

        public void Exit(Player player)
        { }
    }
}