using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.State.GoodExample
{
    using UnityEngine;

    public class IdleState : IPlayerState
    {
        private Player player; // Ссылка на игрока

        public void Enter(Player player)
        {
            this.player = player;
            player.GetSpriteRenderer().color = Color.blue; // Цвет для состояния Idle

            // Подписываемся на события
            InputManager.OnMove += TransitionToRunning;
            InputManager.OnJump += TransitionToJumping;
            InputManager.OnCrouch += TransitionToCrouching;
            InputManager.OnAttack += TransitionToAttacking;
            InputManager.OnDefend += TransitionToDefending;
            InputManager.OnSlide += TransitionToSliding;
            InputManager.OnClimb += TransitionToClimbing;
            InputManager.OnSwim += TransitionToSwimming;
            InputManager.OnFly += TransitionToFlying;
            InputManager.OnDash += TransitionToDashing;
        }

        public void Update(Player player)
        {
            // Обновляем ввод
            InputManager.Update();
        }

        public void Exit(Player player)
        {
            // Отписываемся от событий
            InputManager.OnMove -= TransitionToRunning;
            InputManager.OnJump -= TransitionToJumping;
            InputManager.OnCrouch -= TransitionToCrouching;
            InputManager.OnAttack -= TransitionToAttacking;
            InputManager.OnDefend -= TransitionToDefending;
            InputManager.OnSlide -= TransitionToSliding;
            InputManager.OnClimb -= TransitionToClimbing;
            InputManager.OnSwim -= TransitionToSwimming;
            InputManager.OnFly -= TransitionToFlying;
            InputManager.OnDash -= TransitionToDashing;
        }

        // Методы переходов
        private void TransitionToRunning() => player.TransitionTo(new RunningState());

        private void TransitionToJumping() => player.TransitionTo(new JumpingState());

        private void TransitionToCrouching() => player.TransitionTo(new CrouchingState());

        private void TransitionToAttacking() => player.TransitionTo(new AttackingState());

        private void TransitionToDefending() => player.TransitionTo(new DefendingState());

        private void TransitionToSliding() => player.TransitionTo(new SlidingState());

        private void TransitionToClimbing() => player.TransitionTo(new ClimbingState());

        private void TransitionToSwimming() => player.TransitionTo(new SwimmingState());

        private void TransitionToFlying() => player.TransitionTo(new FlyingState());

        private void TransitionToDashing() => player.TransitionTo(new DashingState());
    }
}