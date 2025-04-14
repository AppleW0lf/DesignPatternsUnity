using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts.Decorator
{
    public class Enemy : MonoBehaviour
    {
        public float speed = 5f;
        public float armor = 0f;
        public float critChance = 0f;

        public void Move()
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); // Простое движение вправо
        }

        // Метод, который использует все параметры (для теста производительности)
        public void SimulateAttack(int iterations = 10000)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                // Симуляция атаки с учетом брони и шанса крита
                float damage = 10f;
                damage -= armor;
                if (Random.value < critChance)
                {
                    damage *= 2f; // Двойной урон при крите
                }
                //Debug.Log("Нанесен урон: " + damage); //Раскоментируйте для просмотра результатов
            }
            stopwatch.Stop();
            UnityEngine.Debug.Log($"[Прямой подход] Время выполнения {iterations} итераций: {stopwatch.ElapsedMilliseconds} мс");
        }

        private void Update()
        {
            Move();
        }
    }
}