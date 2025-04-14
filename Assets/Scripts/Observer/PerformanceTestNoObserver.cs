using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Observer
{
    public class PerformanceTestNoObserver : MonoBehaviour
    {
        public PlayerWithoutObserver player;
        public float damageAmount = 10f;
        public int numDamageEvents = 1000;
        public bool warmUp = true;

        private void Start()
        {
            player = FindFirstObjectByType<PlayerWithoutObserver>();

            if (player == null)
            {
                Debug.LogError("PlayerWithoutObserver не найден в сцене!  Отключение теста без Observer.");
                enabled = false; // Отключаем скрипт
                return;
            }

            if (warmUp)
            {
                Debug.Log("Выполняется разогрев (без Observer)...");
                WarmUp(numDamageEvents);
            }
            TestPerformance();
        }

        private void WarmUp(int numDamageEvents)
        {
            // Разогрев без Observer
            for (int i = 0; i < numDamageEvents; i++)
            {
                player.TakeDamage(damageAmount);
            }
            player.health = 100f; // Восстанавливаем здоровье после разогрева

            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            Debug.Log("Разогрев завершен (без Observer).");
        }

        private void TestPerformance()
        {
            Debug.Log("Начинаем тест производительности (без Observer)...");
            long noObserverTime = TestWithoutObserver(numDamageEvents);
            Debug.Log($"Без Observer: {noObserverTime} ms");
            Debug.Log("Тест производительности завершен (без Observer).");
        }

        private long TestWithoutObserver(int numDamageEvents)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numDamageEvents; i++)
            {
                player.TakeDamage(damageAmount);
            }

            stopwatch.Stop();
            player.health = 100f; // Восстанавливаем здоровье после теста
            return stopwatch.ElapsedMilliseconds;
        }
    }
}