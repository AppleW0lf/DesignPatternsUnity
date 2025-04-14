using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Object_pool
{
    public class TestNoObjectPool : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public int numBullets = 1000;
        public bool warmUp = true;

        private void Start()
        {
            if (warmUp)
            {
                Debug.Log("Выполняется разогрев (без Object Pool)...");
                WarmUp(numBullets);
            }
            TestPerformance();
        }

        private void WarmUp(int numBullets)
        {
            // Разогрев без Object Pool
            for (int i = 0; i < numBullets; i++)
            {
                GameObject bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation);
                Destroy(bulletObj);
            }

            Resources.UnloadUnusedAssets(); // Освобождаем ресурсы после разогрева
            System.GC.Collect(); // Запускаем сборку мусора после разогрева
            Debug.Log("Разогрев завершен (без Object Pool).");
        }

        private void TestPerformance()
        {
            Debug.Log("Начинаем тест производительности (без Object Pool)...");
            long noPoolTime = TestWithoutPool(numBullets);
            Debug.Log($"Без Object Pool: {noPoolTime} ms");
            Debug.Log("Тест производительности завершен (без Object Pool).");
        }

        private long TestWithoutPool(int numBullets)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numBullets; i++)
            {
                GameObject bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation);
                Destroy(bulletObj);
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}