using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Assets.Scripts.MVVM.MVVM
{
    public class TreasureCollectorView : MonoBehaviour
    {
        public TMP_Text scoreText;
        public GameObject coinPrefab;
        public int coinCount = 10;
        public float spawnRange = 5f;

        private TreasureCollectorViewModel _viewModel;
        public List<GameObject> coins = new List<GameObject>();
        private Stopwatch stopwatch = new Stopwatch();
        public double updateTime;

        private void Start()
        {
            TreasureCollectorModel model = new TreasureCollectorModel();
            _viewModel = new TreasureCollectorViewModel(model);
            _viewModel.OnScoreTextChanged += UpdateScoreText;

            SpawnCoins();
        }

        public void SpawnCoins()
        {
            for (int i = 0; i < coinCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnRange, spawnRange), Random.Range(-4, -3));
                GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
                coins.Add(coin);
                coin.GetComponent<CoinMVVM>().collectorView = this;
            }
        }

        public void CollectCoin(GameObject coin)
        {
            _viewModel.CollectCoin();
            coins.Remove(coin);
            Destroy(coin);
        }

        public void UpdateScoreText(string scoreTextString)
        {
            stopwatch.Reset();
            stopwatch.Start();

            scoreText.text = scoreTextString;

            stopwatch.Stop();
            updateTime = stopwatch.Elapsed.TotalMilliseconds;
            Debug.Log("UI Update Time (MVVM): " + updateTime + " ms");
        }

        private void OnDestroy()
        {
            _viewModel.OnScoreTextChanged -= UpdateScoreText;
            _viewModel.Unsubscribe();
        }
    }
}