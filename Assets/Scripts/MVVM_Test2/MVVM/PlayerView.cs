using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVVM_Test2.MVVM
{
    public class PlayerView : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private PlayerViewModel playerViewModel;

        public event Action<Collider2D> TargetCollected; // Событие для обработки столкновений

        private void Start()
        {
            PlayerModel playerModel = new PlayerModel(moveSpeed);
            playerViewModel = new PlayerViewModel(playerModel);

            playerViewModel.PositionChanged += UpdatePosition;
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            playerViewModel.Move(horizontalInput);
        }

        private void UpdatePosition(float newX)
        {
            transform.position = new Vector2(newX, transform.position.y);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<TargetView>() != null)
            {
                TargetCollected?.Invoke(other);
            }
        }

        public PlayerViewModel GetPlayerViewModel()
        {
            return playerViewModel;
        }
    }
}