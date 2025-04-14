using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Decorator
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject baseEnemyPrefab; // Prefab базового врага
        public GameObject EnemyPrefab; // Prefab базового врага
        public float speedMultiplier = 1.5f;
        public float armorBonus = 5f;
        public float critChanceBonus = 0.2f;

        private void Start()
        {
            // Пример создания врага с усиленной скоростью и броней
            GameObject enemyObject = Instantiate(baseEnemyPrefab, Vector3.zero, Quaternion.identity);
            IEnemy baseEnemy = enemyObject.GetComponent<BaseEnemy>();

            SpeedBoost speedBoost = enemyObject.AddComponent<SpeedBoost>();
            speedBoost._enemy = baseEnemy;
            speedBoost.Speed = baseEnemy.Speed;
            speedBoost.speedMultiplier = speedMultiplier;

            ArmorBuff armorBuff = enemyObject.AddComponent<ArmorBuff>();
            armorBuff._enemy = speedBoost; // Декорируем уже усиленного врага
            armorBuff.Armor = speedBoost.Armor;
            armorBuff.armorBonus = armorBonus;

            CritChanceBuff critChanceBuff = enemyObject.AddComponent<CritChanceBuff>();
            critChanceBuff._enemy = armorBuff;
            critChanceBuff.CritChance = armorBuff.CritChance;
            critChanceBuff.critChanceBonus = critChanceBonus;

            //Запускаем тесты
            baseEnemy.SimulateAttack();
            speedBoost.SimulateAttack();
            armorBuff.SimulateAttack();
            critChanceBuff.SimulateAttack();

            Enemy enemy = EnemyPrefab.AddComponent<Enemy>();
            enemy.SimulateAttack();

            // Теперь у врага есть скорость, увеличенная в 1.5 раза, и 5 единиц брони.
        }
    }
}