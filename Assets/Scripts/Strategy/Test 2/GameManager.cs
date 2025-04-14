using UnityEngine;
using System.Collections;
using Assets.Scripts.Strategy.Test_2;

namespace Assets.Scripts.Strategy.Test_2
{
    public class GameManager : MonoBehaviour
    {
        public Character character;

        private void Start()
        {
            // Запускаем корутину для смены стратегий
            StartCoroutine(CycleStrategies());
        }

        private IEnumerator CycleStrategies()
        {
            while (true) // Бесконечный цикл
            {
                // Меняем стратегию на ходьбу
                character.SetMoveStrategy(new WalkStrategy());
                Debug.Log("Стратегия: Ходьба");
                yield return new WaitForSeconds(2f); // Ждем 2 секунды

                // Меняем стратегию на бег
                character.SetMoveStrategy(new RunStrategy());
                Debug.Log("Стратегия: Бег");
                yield return new WaitForSeconds(2f); // Ждем 2 секунды

                // Меняем стратегию на полет
                character.SetMoveStrategy(new FlyStrategy());
                Debug.Log("Стратегия: Полет");
                yield return new WaitForSeconds(2f); // Ждем 2 секунды
            }
        }
    }
}