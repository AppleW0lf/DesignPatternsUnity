using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Decorator
{
    // 1. Базовый компонент (интерфейс)
    public interface IEnemy
    {
        float Speed { get; set; }
        float Armor { get; set; }
        float CritChance { get; set; }

        void Move();

        void SimulateAttack(int iterations = 10000);
    }

    // 2. Конкретный компонент (базовый враг)
    public class BaseEnemy : MonoBehaviour, IEnemy
    {
        public float Speed { get; set; } = 5f;
        public float Armor { get; set; } = 0f;
        public float CritChance { get; set; } = 0f;

        public void Move()
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }

        public void SimulateAttack(int iterations = 10000)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                float damage = 10f;
                damage -= Armor;
                if (Random.value < CritChance)
                {
                    damage *= 2f;
                }
                //Debug.Log("Нанесен урон: " + damage); //Раскоментируйте для просмотра результатов
            }
            stopwatch.Stop();
            UnityEngine.Debug.Log($"[Базовый враг] Время выполнения {iterations} итераций: {stopwatch.ElapsedMilliseconds} мс");
        }

        private void Update()
        {
            Move();
        }
    }
}