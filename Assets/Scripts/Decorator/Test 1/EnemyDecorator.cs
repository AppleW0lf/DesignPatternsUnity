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
    public abstract class EnemyDecorator : MonoBehaviour, IEnemy
    {
        // Использовать public, чтобы  базовые классы могли получить доступ
        public IEnemy _enemy { get; set; }  // Важно: public с автоматическим свойством!

        //Удалить конструктор, т.к. он не нужен

        public virtual float Speed { get; set; }
        public virtual float Armor { get; set; }
        public virtual float CritChance { get; set; }

        public virtual void Move()
        {
            _enemy.Move();
        }

        public virtual void SimulateAttack(int iterations = 10000)
        {
            _enemy.SimulateAttack(iterations);
        }
    }

    // 4. Конкретные декораторы (например, усиление скорости, брони, крит. шанса)
    public class SpeedBoost : EnemyDecorator
    {
        private float _speedMultiplier;
        //Удалить конструктор, т.к. он не нужен

        public float speedMultiplier { get; set; }

        public override float Speed
        {
            get { return _enemy.Speed * speedMultiplier; }
            set { _enemy.Speed = value; }
        }

        public override void Move()
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
    }

    public class ArmorBuff : EnemyDecorator
    {
        private float _armorBonus;
        //Удалить конструктор, т.к. он не нужен

        public float armorBonus { get; set; }

        public override float Armor
        {
            get { return _enemy.Armor + armorBonus; }
            set { _enemy.Armor = value; }
        }

        public override void SimulateAttack(int iterations = 10000)
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
            UnityEngine.Debug.Log($"[Усиленная броня] Время выполнения {iterations} итераций: {stopwatch.ElapsedMilliseconds} мс");
        }
    }

    public class CritChanceBuff : EnemyDecorator
    {
        private float _critChanceBonus;

        //Удалить конструктор, т.к. он не нужен

        public float critChanceBonus { get; set; }

        public override float CritChance
        {
            get { return _enemy.CritChance + critChanceBonus; }
            set { _enemy.CritChance = value; }
        }

        public override void SimulateAttack(int iterations = 10000)
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
            UnityEngine.Debug.Log($"[Шанс крит. удара] Время выполнения {iterations} итераций: {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}