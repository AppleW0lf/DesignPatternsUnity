using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Strategy.Test_2
{
    using UnityEngine;
    using System.Diagnostics;
    using System.Collections.Generic;
    using Debug = UnityEngine.Debug;

    public class StrategyPerformanceTest : MonoBehaviour
    {
        public Transform parent;
        public GameObject characterPrefab;
        public int objectCount = 10000; // Количество объектов
        private List<Character> characters = new List<Character>();

        private void Start()
        {
            // Создаем объекты с разными стратегиями
            for (int i = 0; i < objectCount; i++)
            {
                //var character = new GameObject($"Character_{i}").AddComponent<Character>();
                GameObject characterObject = Instantiate(characterPrefab, parent);
                Character character = characterObject.GetComponent<Character>();
                if (i % 2 == 0)
                {
                    character.SetMoveStrategy(new WalkStrategy());
                    Debug.Log($"Character_{i} Стратегия: Ходьба");
                }
                else
                {
                    character.SetMoveStrategy(new RunStrategy());
                    Debug.Log($"Character_{i} Стратегия: Бег");
                }
                characters.Add(character);
            }

            // Замеряем время выполнения
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Выполняем обновление
            for (int i = 0; i < 100; i++) // 100 кадров
            {
                foreach (var character in characters)
                {
                    character.Update();
                }
            }

            stopwatch.Stop();
            UnityEngine.Debug.Log($"Strategy Pattern Time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}