using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.MVC
{
    public class PerformanceTester : MonoBehaviour
    {
        public bool useMVC = false;
        public GameObject enemyPrefabMonolithic;
        public GameObject enemyPrefabMVC;
        public int numberOfEnemies = 100;
        public float damageInterval = 0.1f;
        public int damageAmount = 5;
        public float spawnRadius = 10f;
        private float _damageTimer = 0f;

        private Stopwatch _stopwatch;
        private GameObject[] _enemies;

        private void Start()
        {
            SpawnEnemies();
            _stopwatch = new Stopwatch();
        }

        private void SpawnEnemies()
        {
            GameObject prefab = useMVC ? enemyPrefabMVC : enemyPrefabMonolithic;

            for (int i = 0; i < numberOfEnemies; i++)
            {
                Vector2 randomPosition = UnityEngine.Random.insideUnitCircle * spawnRadius;
                Vector3 spawnPosition = new Vector3(randomPosition.x, randomPosition.y, 0f);
                Instantiate(prefab, spawnPosition, Quaternion.identity);
            }
            _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }

        private void Update()
        {
            _damageTimer += Time.deltaTime;
            if (_damageTimer >= damageInterval)
            {
                _damageTimer = 0f;
                _stopwatch.Start();
                if (useMVC)
                {
                    ApplyDamageMVC();
                }
                else
                {
                    ApplyDamageMonolithic();
                }
                _stopwatch.Stop();

                long elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;
                Debug.Log($"{(useMVC ? "MVC" : "Monolithic")} - Time to apply damage: {elapsedMilliseconds} ms");
                _stopwatch.Reset();
            }
        }

        private void ApplyDamageMonolithic()
        {
            foreach (var enemyObject in _enemies)
            {
                EnemyMonolithic enemy = enemyObject.GetComponent<EnemyMonolithic>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damageAmount);
                }
            }
        }

        private void ApplyDamageMVC()
        {
            foreach (var enemyObject in _enemies)
            {
                EnemyController controller = enemyObject.GetComponent<EnemyController>();
                if (controller != null)
                {
                    controller.TakeDamage(damageAmount);
                }
            }
        }
    }
}