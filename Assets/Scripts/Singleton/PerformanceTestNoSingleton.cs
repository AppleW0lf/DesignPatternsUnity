using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Singleton
{
    public class PerformanceTestNoSingleton : MonoBehaviour
    {
        public int numIterations = 10000; // Количество итераций для теста
        public GameManagerWithoutSingleton gameManager;
        public bool warmUp = true;

        private void Start()
        {
            // Кэшируем ссылку на GameManager, ищем его только один раз
            gameManager = FindFirstObjectByType<GameManagerWithoutSingleton>();

            if (gameManager == null)
            {
                Debug.LogError("GameManagerWithoutSingleton не найден в сцене!");
                enabled = false; // Отключаем скрипт
                return;
            }
            if (warmUp)
            {
                Debug.Log("Выполняется разогрев (без Singleton)...");
                WarmUp();
            }

            TestPerformance();
        }

        private void WarmUp()
        {
            // Выполняем несколько итераций для "разогрева"
            for (int i = 0; i < numIterations; i++)
            {
                gameManager.IncreaseScore(1);
                gameManager.AddCoins(1);
            }
            gameManager.score = 0; // Сбрасываем значения
            gameManager.coins = 100;
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            Debug.Log("Разогрев завершен (без Singleton).");
        }

        private void TestPerformance()
        {
            Debug.Log("Начинаем тест производительности (без Singleton)...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numIterations; i++)
            {
                gameManager.IncreaseScore(1);
                gameManager.AddCoins(1);
            }

            stopwatch.Stop();
            Debug.Log($"Без Singleton: {stopwatch.ElapsedMilliseconds} ms");
            Debug.Log($"Final Score (Без Singleton): {gameManager.score}");

            gameManager.score = 0; // Сбрасываем значения
            gameManager.coins = 100;
        }
    }
}