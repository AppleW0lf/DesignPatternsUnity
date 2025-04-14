using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Strategy.Test_2
{
    public class NoStrategyPerformanceTest : MonoBehaviour
    {
        public Transform parent;
        public GameObject characterPrefab;
        public int objectCount = 10000; // Количество объектов
        private List<CharacterWithoutStrategy> characters = new List<CharacterWithoutStrategy>();

        private void Start()
        {
            // Создаем объекты с разными типами поведения
            for (int i = 0; i < objectCount; i++)
            {
                GameObject characterObject = Instantiate(characterPrefab, parent);
                CharacterWithoutStrategy character = characterObject.GetComponent<CharacterWithoutStrategy>();
                //var character = new GameObject($"Character_{i}").AddComponent<CharacterWithoutStrategy>();
                if (i % 2 == 0)
                {
                    character.SetMoveType(CharacterWithoutStrategy.MoveType.Walk);
                    Debug.Log($"Character_{i} Стратегия: Ходьба");
                }
                else
                {
                    character.SetMoveType(CharacterWithoutStrategy.MoveType.Run);
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
            UnityEngine.Debug.Log($"No Strategy Time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}