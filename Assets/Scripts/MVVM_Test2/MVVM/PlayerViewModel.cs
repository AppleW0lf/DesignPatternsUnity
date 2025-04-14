using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVVM_Test2.MVVM
{
    public class PlayerViewModel
    {
        public PlayerModel PlayerModel { get; }

        public event Action<float> PositionChanged;

        public PlayerViewModel(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
        }

        public void Move(float horizontalInput)
        {
            PlayerModel.PositionX += horizontalInput * PlayerModel.MoveSpeed * Time.deltaTime;
            PositionChanged?.Invoke(PlayerModel.PositionX); // Сообщаем View об изменении позиции
        }
    }
}