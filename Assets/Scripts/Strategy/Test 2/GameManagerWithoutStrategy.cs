using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy.Test_2
{
    public class GameManagerWithoutStrategy : MonoBehaviour
    {
        public CharacterWithoutStrategy character;

        private void Start()
        {
            // Запускаем корутину для смены состояний
            StartCoroutine(CycleMoveTypes());
        }

        private IEnumerator CycleMoveTypes()
        {
            while (true) // Бесконечный цикл
            {
                // Меняем состояние на ходьбу
                character.SetMoveType(CharacterWithoutStrategy.MoveType.Walk);
                Debug.Log("Состояние: Ходьба");
                yield return new WaitForSeconds(2f); // Ждем 2 секунды

                // Меняем состояние на бег
                character.SetMoveType(CharacterWithoutStrategy.MoveType.Run);
                Debug.Log("Состояние: Бег");
                yield return new WaitForSeconds(2f); // Ждем 2 секунды

                // Меняем состояние на полет
                character.SetMoveType(CharacterWithoutStrategy.MoveType.Fly);
                Debug.Log("Состояние: Полет");
                yield return new WaitForSeconds(2f); // Ждем 2 секунды
            }
        }
    }
}