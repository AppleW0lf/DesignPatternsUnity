using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy.Test_1
{
    public class MeleeAttackStrategyPerformanceNoPool : AttackStrategy
    {
        public GameObject attackPrefab;

        public override void Attack(Transform attacker, GameObject player)
        {
            if (CanAttack())
            {
                Instantiate(attackPrefab, attacker.position, Quaternion.identity);
                lastAttackTime = Time.time;
            }
        }
    }

    public class RangedAttackStrategyPerformanceNoPool : AttackStrategy
    {
        public GameObject attackPrefab;

        public override void Attack(Transform attacker, GameObject player)
        {
            if (CanAttack())
            {
                GameObject attack = Instantiate(attackPrefab, attacker.position, CalculateRotationToPlayer(attacker, player));
                lastAttackTime = Time.time;
            }
        }

        private Quaternion CalculateRotationToPlayer(Transform attacker, GameObject player)
        {
            Vector2 direction = player.transform.position - attacker.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public class AoEAttackStrategyPerformanceNoPool : AttackStrategy
    {
        public GameObject attackPrefab;

        public override void Attack(Transform attacker, GameObject player)
        {
            if (CanAttack())
            {
                Instantiate(attackPrefab, attacker.position, Quaternion.identity);
                lastAttackTime = Time.time;
            }
        }
    }

    // Класс AI врага с использованием паттерна Strategy
    public class EnemyAIWithStrategyPerformanceNoPool : MonoBehaviour
    {
        public float meleeRange = 2f;
        public float rangedRange = 10f;
        public float aoeRange = 5f;

        private GameObject player;
        private AttackStrategy currentAttackStrategy;
        public MeleeAttackStrategyPerformanceNoPool meleeStrategy;
        public RangedAttackStrategyPerformanceNoPool rangedStrategy;
        public AoEAttackStrategyPerformanceNoPool aoeStrategy;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player"); // Предполагаем, что у игрока тэг "Player"
            if (meleeStrategy == null || rangedStrategy == null || aoeStrategy == null)
            {
                Debug.LogError("One or more strategies are not assigned!");
            }
            else
            {
                currentAttackStrategy = meleeStrategy;
            }
        }

        private void Update()
        {
            if (player == null) return;

            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= meleeRange)
            {
                currentAttackStrategy = meleeStrategy;
            }
            else if (distanceToPlayer <= rangedRange && distanceToPlayer > meleeRange)
            {
                currentAttackStrategy = rangedStrategy;
            }
            else if (distanceToPlayer <= aoeRange)
            {
                currentAttackStrategy = aoeStrategy;
            }

            currentAttackStrategy.Attack(transform, player);
        }
    }
}