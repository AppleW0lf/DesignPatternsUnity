﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.State.GoodExample
{
    using UnityEngine;

    public class FlyingState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.GetSpriteRenderer().color = new Color(1, 0.5f, 0); // Цвет для состояния Flying
        }

        public void Update(Player player)
        {
            if (!Input.GetKey(KeyCode.F))
            {
                player.TransitionTo(new IdleState());
            }
        }

        public void Exit(Player player)
        { }
    }
}