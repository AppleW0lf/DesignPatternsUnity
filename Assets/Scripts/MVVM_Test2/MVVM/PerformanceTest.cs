using Assets.Scripts.MVVM_Test2.NoMVVM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Assets.Scripts.MVVM_Test2.MVVM
{
    public class PerformanceTest : MonoBehaviour
    {
        public int numberOfTargets = 100;
        public int numberOfIterations = 1000;
        public GameObject targetPrefab;
        public GameObject playerPrefab;
        public Transform playerSpawnPoint;
        public bool useMVVM = false;

        // Spaghetti Code
        public GameObject spaghettiGameManagerPrefab;

        private GameManager spaghettiGameManager;
        private PlayerController spaghettiPlayerController;
        private GameObject[] spaghettiTargets;

        // MVVM
        public GameObject mvvmGameViewPrefab;

        private GameView mvvmGameView;
        private PlayerView mvvmPlayerView;

        private void Start()
        {
            if (useMVVM)
            {
                mvvmGameView = Instantiate(mvvmGameViewPrefab).GetComponent<GameView>();
                mvvmGameView.playerPrefab = playerPrefab;
                mvvmGameView.playerSpawnPoint = playerSpawnPoint;
                mvvmGameView.targetPrefab = targetPrefab;
                mvvmGameView.numberOfTargets = numberOfTargets;
                mvvmGameView.scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
                mvvmPlayerView = FindFirstObjectByType<PlayerView>();
                TestMVVM();
            }
            else
            {
                spaghettiGameManager = Instantiate(spaghettiGameManagerPrefab).GetComponent<GameManager>();
                spaghettiGameManager.playerPrefab = playerPrefab;
                spaghettiGameManager.playerSpawnPoint = playerSpawnPoint;
                spaghettiGameManager.targetPrefab = targetPrefab;
                spaghettiGameManager.numberOfTargets = numberOfTargets;
                spaghettiPlayerController = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity).GetComponent<PlayerController>();

                playerSpawnPoint.position = new Vector3(0, 0, 0);
                spaghettiGameManager.scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

                spaghettiTargets = new GameObject[numberOfTargets];
                for (int i = 0; i < numberOfTargets; i++)
                {
                    Vector2 randomPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
                    spaghettiTargets[i] = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
                    spaghettiTargets[i].SetActive(false); // Деактивируем цели, т.к. не собираем
                }
                TestSpaghettiCode();
            }

            // Очистка сцены
            /*DestroyImmediate(spaghettiGameManager.gameObject);
            DestroyImmediate(mvvmGameView.gameObject);

            foreach (var target in spaghettiTargets)
            {
                DestroyImmediate(target);
            }

            GameObject[] mvvmTargets = GameObject.FindGameObjectsWithTag("Target");

            foreach (GameObject target in mvvmTargets)
            {
                DestroyImmediate(target);
            }
            Debug.Log("Tests Complete");*/
        }

        private void TestSpaghettiCode()
        {
            Stopwatch stopwatch = new Stopwatch();
            float startTime, endTime;
            float totalTime = 0f;

            stopwatch.Start();
            startTime = Time.realtimeSinceStartup;

            for (int iteration = 0; iteration < numberOfIterations; iteration++)
            {
                // Симулируем сбор цели (увеличение счетчика)
                spaghettiGameManager.CollectTarget();
            }

            stopwatch.Stop();
            endTime = Time.realtimeSinceStartup;
            totalTime = endTime - startTime;

            UnityEngine.Debug.Log($"Spaghetti Code - Time to collect {numberOfIterations} targets: {stopwatch.ElapsedMilliseconds} ms.  Realtime since startup: {totalTime}");
        }

        private void TestMVVM()
        {
            Stopwatch stopwatch = new Stopwatch();
            float startTime, endTime;
            float totalTime = 0f;

            stopwatch.Start();
            startTime = Time.realtimeSinceStartup;

            for (int iteration = 0; iteration < numberOfIterations; iteration++)
            {
                // Симулируем сбор цели (увеличение счетчика через ViewModel)
                mvvmGameView.gameViewModel.CollectTarget();
            }
            stopwatch.Stop();
            endTime = Time.realtimeSinceStartup;
            totalTime = endTime - startTime;

            UnityEngine.Debug.Log($"MVVM - Time to collect {numberOfIterations} targets: {stopwatch.ElapsedMilliseconds} ms. Realtime since startup: {totalTime}");
        }
    }
}