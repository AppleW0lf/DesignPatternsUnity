using Assets.Scripts.State.BadExample;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Assets.Scripts.State
{
    public class PerformanceTestNoState : MonoBehaviour
    {
        public GameObject playerPrefab; // Префаб объекта игрока
        public int numberOfPlayers = 100;
        public int numIterations = 10000; // Количество итераций для теста
        public bool warmUp = true;

        private void Start()
        {
            if (warmUp)
            {
                Debug.Log("Выполняется разогрев (без State Pattern)...");
                WarmUp();
            }
            TestPerformance();
        }

        private void CreatePlayers()
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Vector3 position = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0);
                Instantiate(playerPrefab, position, Quaternion.identity);
            }
        }

        private void WarmUp()
        {
            CreatePlayers();

            PlayerController[] players = FindObjectsByType<PlayerController>(FindObjectsSortMode.None);
            if (players == null || players.Length == 0)
            {
                Debug.LogError("PlayerController не найден в сцене!");
                return;
            }
            for (int i = 0; i < numIterations; i++)
            {
                foreach (var player in players)
                {
                    if (player == null) continue;
                    // Эмулируем смену состояний (устанавливаем случайное состояние)
                    PlayerController.PlayerState randomState = (PlayerController.PlayerState)Random.Range(0, 11);
                    player.CurrentState = randomState;
                    // Обновляем состояние
                    player.UpdateState();
                }
            }
            // Уничтожаем игроков после разогрева
            foreach (PlayerController player in players)
            {
                if (player != null)
                    Destroy(player.gameObject);
            }
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            Debug.Log("Разогрев завершен (без State Pattern).");
        }

        private void TestPerformance()
        {
            Debug.Log("Начинаем тест производительности (без State Pattern)...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Создаем игроков для теста
            CreatePlayers();
            PlayerController[] players = FindObjectsByType<PlayerController>(FindObjectsSortMode.None);
            if (players == null || players.Length == 0)
            {
                Debug.LogError("PlayerController не найден в сцене!");
                return;
            }
            for (int i = 0; i < numIterations; i++)
            {
                foreach (var player in players)
                {
                    if (player == null) continue;
                    // Эмулируем смену состояний (устанавливаем случайное состояние)
                    PlayerController.PlayerState randomState = (PlayerController.PlayerState)Random.Range(0, 11);
                    player.CurrentState = randomState;
                    // Обновляем состояние
                    player.UpdateState();
                }
            }

            stopwatch.Stop();
            Debug.Log($"Без State Pattern: {stopwatch.ElapsedMilliseconds} ms");

            // Уничтожаем игроков после теста
            foreach (PlayerController player in players)
            {
                if (player != null)
                    Destroy(player.gameObject);
            }
        }
    }
}