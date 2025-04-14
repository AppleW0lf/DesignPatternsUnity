using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.State.GoodExample
{
    using UnityEngine;

    public class AttackingState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.GetSpriteRenderer().color = Color.magenta; // Цвет для состояния Attacking
        }

        public void Update(Player player)
        {
            if (!Input.GetKey(KeyCode.Mouse0))
            {
                player.TransitionTo(new IdleState());
            }
        }

        public void Exit(Player player)
        { }
    }
}