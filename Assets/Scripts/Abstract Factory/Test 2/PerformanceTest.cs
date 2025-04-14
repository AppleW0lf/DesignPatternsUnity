using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Abstract_Factory.Test_2
{
    public class PerformanceTest : MonoBehaviour
    {
        public EnemySpawnerWithoutFactory spawnerWithoutFactory;
        public EnemySpawnerWithFactory spawnerWithFactory;
        public FlyingEnemyFactory flyingFactory;
        public GroundEnemyFactory groundFactory;

        public Transform spawnPoint;

        public int numberOfEnemiesToSpawn = 1000;
        public string enemyTypeToSpawn = "Plane"; // Для спавнера без фабрики

        private void Start()
        {
            TestPerformance();
        }

        private void TestPerformance()
        {
            if (spawnerWithoutFactory == null || spawnerWithFactory == null || flyingFactory == null || groundFactory == null)
            {
                Debug.LogError("Assign spawners and factories in the inspector!");
                return;
            }

            // Устанавливаем позицию спавна для всех спавнеров
            spawnerWithoutFactory.spawnPoint = spawnPoint;
            spawnerWithFactory.spawnPoint = spawnPoint;

            // Тест без Abstract Factory
            Stopwatch stopwatchWithoutFactory = new Stopwatch();
            stopwatchWithoutFactory.Start();
            for (int i = 0; i < numberOfEnemiesToSpawn; i++)
            {
                spawnerWithoutFactory.SpawnEnemy(enemyTypeToSpawn);
            }
            stopwatchWithoutFactory.Stop();
            UnityEngine.Debug.Log("Time without Abstract Factory: " + stopwatchWithoutFactory.ElapsedMilliseconds + " ms");

            // Очищаем все созданные объекты
            DestroyAllEnemies();

            // Тест с Abstract Factory
            Stopwatch stopwatchWithFactory = new Stopwatch();
            stopwatchWithFactory.Start();

            // Пример: Спавн летающих врагов
            spawnerWithFactory.factory = flyingFactory;
            for (int i = 0; i < numberOfEnemiesToSpawn; i++)
            {
                spawnerWithFactory.SpawnEnemy();
            }

            // Пример: Спавн наземных врагов
            //spawnerWithFactory.factory = groundFactory;
            //for (int i = 0; i < numberOfEnemiesToSpawn; i++)
            //{
            //    spawnerWithFactory.SpawnEnemy();
            //}

            stopwatchWithFactory.Stop();
            UnityEngine.Debug.Log("Time with Abstract Factory: " + stopwatchWithFactory.ElapsedMilliseconds + " ms");

            // Очищаем все созданные объекты
            DestroyAllEnemies();
        }

        private void DestroyAllEnemies()
        {
            Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None); //  Используем новый метод и отключаем сортировку
            foreach (Enemy enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}