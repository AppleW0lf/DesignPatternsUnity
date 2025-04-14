using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.State.GoodExample
{
    using UnityEngine;

    public class SlidingState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.GetSpriteRenderer().color = Color.gray; // Цвет для состояния Sliding
        }

        public void Update(Player player)
        {
            if (!Input.GetKey(KeyCode.C))
            {
                player.TransitionTo(new IdleState());
            }
        }

        public void Exit(Player player)
        { }
    }
}