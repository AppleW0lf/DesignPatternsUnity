using Assets.Scripts.MVVM.MVVM;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.MVVM.NoMVVM
{
    public class TreasureCollectorNoMVVM : MonoBehaviour
    {
        public TMP_Text scoreText;
        public GameObject coinPrefab;
        public int coinCount = 10;
        public float spawnRange = 5f;

        private int score = 0;
        public List<GameObject> coins = new List<GameObject>();
        private Stopwatch stopwatch = new Stopwatch();
        public double updateTime;

        private void Start()
        {
            SpawnCoins();
            UpdateScoreText();
        }

        public void SpawnCoins()
        {
            for (int i = 0; i < coinCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnRange, spawnRange), Random.Range(-4, -2));
                GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
                coins.Add(coin);
                coin.GetComponent<CoinNoMVVM>().collector = this;
            }
        }

        public void CollectCoin(GameObject coin)
        {
            score++;
            coins.Remove(coin);
            Destroy(coin);
            UpdateScoreText();
        }

        public void UpdateScoreText()
        {
            stopwatch.Reset();
            stopwatch.Start();

            scoreText.text = "Score: " + score;

            stopwatch.Stop();
            updateTime = stopwatch.Elapsed.TotalMilliseconds;
            Debug.Log("UI Update Time (No MVVM): " + updateTime + " ms");
        }
    }
}