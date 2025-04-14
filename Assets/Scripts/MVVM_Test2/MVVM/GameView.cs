using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.MVVM_Test2.MVVM
{
    public class GameView : MonoBehaviour
    {
        public int numberOfTargets = 10;
        public GameObject playerPrefab;
        public Transform playerSpawnPoint;
        public GameObject targetPrefab;
        public TextMeshProUGUI scoreText;
        public GameViewModel gameViewModel;
        private PlayerView playerView;
        private List<GameObject> targetViews = new List<GameObject>(); // Для хранения целей

        public void Start()
        {
            // 1. Инициализация моделей и ViewModels
            GameModel gameModel = new GameModel(numberOfTargets);
            PlayerView player = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity).GetComponent<PlayerView>();

            PlayerViewModel playerViewModel = player.GetPlayerViewModel();
            gameViewModel = new GameViewModel(gameModel, playerViewModel);

            // 2. Подписка на события
            gameViewModel.ScoreChanged += UpdateScoreText;
            player.TargetCollected += OnTargetCollected;

            // 3. Спавн целей (TargetView)
            foreach (var targetViewModel in gameViewModel.TargetViewModels)
            {
                GameObject targetInstance = Instantiate(targetPrefab, new Vector3(targetViewModel.TargetModel.PositionX, targetViewModel.TargetModel.PositionY, 0), Quaternion.identity);
                targetViews.Add(targetInstance);
            }
            TestMVVM();
        }

        private void UpdateScoreText(int score)
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score.ToString();
            }
        }

        private void OnTargetCollected(Collider2D targetCollider)
        {
            gameViewModel.CollectTarget();
            Destroy(targetCollider.gameObject); // Удаление целевого объекта
            UpdateTargetViews(); // Обновление списка целей в View
        }

        // Метод для обновления списка целей в View (убираем собранные)
        private void UpdateTargetViews()
        {
            foreach (var targetView in targetViews)
            {
                if (targetView == null)
                {
                    continue; // Если цель уже уничтожена
                }
                TargetView target = targetView.GetComponent<TargetView>();
                if (target == null)
                    continue;

                if (!target.gameObject.activeSelf)
                {
                    targetViews.Remove(targetView);
                    break;
                }
            }
        }

        private void TestMVVM()
        {
            Stopwatch stopwatch = new Stopwatch();
            float startTime, endTime;
            float totalTime = 0f;

            stopwatch.Start();
            startTime = Time.realtimeSinceStartup;

            for (int iteration = 0; iteration < 50000; iteration++)
            {
                // Симулируем сбор цели (увеличение счетчика через ViewModel)
                gameViewModel.CollectTarget();
            }
            stopwatch.Stop();
            endTime = Time.realtimeSinceStartup;
            totalTime = endTime - startTime;

            UnityEngine.Debug.Log($"MVVM - Time to collect {50000} targets: {stopwatch.ElapsedMilliseconds} ms. Realtime since startup: {totalTime}");
        }
    }
}