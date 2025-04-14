﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.State.GoodExample
{
    using UnityEngine;

    public class DefendingState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.GetSpriteRenderer().color = Color.cyan; // Цвет для состояния Defending
        }

        public void Update(Player player)
        {
            if (!Input.GetKey(KeyCode.Mouse1))
            {
                player.TransitionTo(new IdleState());
            }
        }

        public void Exit(Player player)
        { }
    }
}