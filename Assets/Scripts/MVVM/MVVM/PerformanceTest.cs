using Assets.Scripts.MVVM.NoMVVM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.MVVM.MVVM
{
    public class PerformanceTest : MonoBehaviour
    {
        public bool useMVVM = false;
        public TreasureCollectorNoMVVM collectorNoMVVM;
        public TreasureCollectorView collectorViewMVVM;
        public int iterations = 100; // Или больше
        public float testDuration = 5f; // Продолжительность теста (секунды)

        private List<double> noMVVMTimes = new List<double>();
        private List<double> mvvmTimes = new List<double>();

        private IEnumerator Start()
        {
            Debug.Log("Starting Performance Tests...");

            // Отключаем управление игроком, чтобы тест был более предсказуемым.
            // (Добавьте логику управления игроком, если вам нужно перемещать его для сбора монет)
            if (!useMVVM)
            {
                Debug.Log("Testing No MVVM...");
                yield return StartCoroutine(RunTestNoMVVM());
                double avgNoMVVM = CalculateAverage(noMVVMTimes);
                Debug.Log("Average UI Update Time (No MVVM): " + avgNoMVVM + " ms");
            }
            else
            {
                Debug.Log("Testing MVVM...");
                yield return StartCoroutine(RunTestMVVM());
                double avgMVVM = CalculateAverage(mvvmTimes);
                Debug.Log("Average UI Update Time (MVVM): " + avgMVVM + " ms");
            }

            Debug.Log("Performance Tests Finished!");
        }

        private IEnumerator RunTestNoMVVM()
        {
            // Симулируем сбор монет в течение testDuration.
            // (В реальной игре игрок бы перемещался и собирал монеты.  Здесь мы упрощаем тест.)

            float startTime = Time.time;
            while (Time.time - startTime < testDuration)
            {
                // Находим ближайшую монету и собираем ее (имитируем).
                if (collectorNoMVVM.coins.Count > 0)
                {
                    GameObject coin = FindClosestCoin(collectorNoMVVM.transform, collectorNoMVVM.coins);
                    collectorNoMVVM.CollectCoin(coin);
                }
                else
                {
                    // Если монеты закончились, создаем новые.
                    collectorNoMVVM.SpawnCoins();
                }
                yield return null; // Ждем один кадр.
                noMVVMTimes.Add(collectorNoMVVM.updateTime);
            }

            Debug.Log("Test NoMVVM completed.");
        }

        private IEnumerator RunTestMVVM()
        {
            float startTime = Time.time;
            while (Time.time - startTime < testDuration)
            {
                if (collectorViewMVVM.coins.Count > 0)
                {
                    GameObject coin = FindClosestCoin(collectorViewMVVM.transform, collectorViewMVVM.coins);
                    collectorViewMVVM.CollectCoin(coin);
                }
                else
                {
                    collectorViewMVVM.SpawnCoins();
                }
                yield return null;
                mvvmTimes.Add(collectorViewMVVM.updateTime);
            }

            Debug.Log("Test MVVM completed.");
        }

        private GameObject FindClosestCoin(Transform origin, List<GameObject> coins)
        {
            GameObject closest = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = origin.position;
            foreach (GameObject coin in coins)
            {
                if (coin != null)
                { // Проверяем, что монета не была уничтожена
                    float dist = Vector3.Distance(coin.transform.position, currentPos);
                    if (dist < minDist)
                    {
                        closest = coin;
                        minDist = dist;
                    }
                }
            }
            return closest;
        }

        private double CalculateAverage(List<double> list)
        {
            double sum = 0;
            foreach (double time in list)
            {
                sum += time;
            }
            return sum / list.Count;
        }
    }
}