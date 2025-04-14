using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.State.GoodExample
{
    using UnityEngine;

    public class RunningState : IPlayerState
    {
        public void Enter(Player player)
        {
            if (player == null)
            {
                Debug.Log("Player is null");
            }
            player.GetSpriteRenderer().color = Color.green;
            //player.GetComponent<SpriteRenderer>().color = Color.green;
            if (player.GetComponent<SpriteRenderer>() is null)
            {
                Debug.Log("SpriteRender is null");
            }
        }

        public void Update(Player player)
        {
            float moveDirection = Input.GetAxis("Horizontal");
            player.transform.Translate(Vector2.right * moveDirection * Time.deltaTime * 5f);

            if (moveDirection == 0)
            {
                player.TransitionTo(new IdleState());
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                player.TransitionTo(new JumpingState());
            }
        }

        public void Exit(Player player)
        { }
    }
}