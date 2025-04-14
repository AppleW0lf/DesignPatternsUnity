using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

namespace Assets.Scripts.MVVM_Test2.NoMVVM
{
    public class GameManager : MonoBehaviour
    {
        public GameObject playerPrefab;
        public Transform playerSpawnPoint;
        public GameObject targetPrefab;
        public int numberOfTargets = 10;
        public TextMeshProUGUI scoreText;
        private int score = 0;

        private void Start()
        {
            // Спавним игрока
            Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);

            // Спавним цели
            for (int i = 0; i < numberOfTargets; i++)
            {
                Vector2 randomPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, -3f)); // Пример рандома
                Instantiate(targetPrefab, randomPosition, Quaternion.identity);
            }
            TestSpaghettiCode();
        }

        private void TestSpaghettiCode()
        {
            Stopwatch stopwatch = new Stopwatch();
            float startTime, endTime;
            float totalTime = 0f;

            stopwatch.Start();
            startTime = Time.realtimeSinceStartup;

            for (int iteration = 0; iteration < 50000; iteration++)
            {
                // Симулируем сбор цели (увеличение счетчика)
                CollectTarget();
            }

            stopwatch.Stop();
            endTime = Time.realtimeSinceStartup;
            totalTime = endTime - startTime;

            UnityEngine.Debug.Log($"Spaghetti Code - Time to collect {50000} targets: {stopwatch.ElapsedMilliseconds} ms.  Realtime since startup: {totalTime}");
        }

        public void CollectTarget() // Метод для увеличения счета
        {
            score++;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score.ToString();
            }
        }
    }
}