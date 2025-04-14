using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy.Test_1
{
    public class EnemyAIWithoutStrategy : MonoBehaviour
    {
        public float meleeRange = 2f;
        public float rangedRange = 10f;
        public float aoeRange = 5f;
        public float attackCooldown = 1f;

        public GameObject meleeAttackPrefab;
        public GameObject rangedAttackPrefab;
        public GameObject aoeAttackPrefab;

        private GameObject player;
        private float lastAttackTime;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            lastAttackTime = Time.time;
        }

        private void Update()
        {
            if (player == null) return;

            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= meleeRange)
            {
                MeleeAttack();
            }
            else if (distanceToPlayer <= rangedRange && distanceToPlayer > meleeRange)
            {
                RangedAttack();
            }
            else if (distanceToPlayer <= aoeRange)
            {
                AoEAttack();
            }
        }

        private void MeleeAttack()
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                Instantiate(meleeAttackPrefab, transform.position, Quaternion.identity);
                lastAttackTime = Time.time;
            }
        }

        private void RangedAttack()
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                GameObject attack = Instantiate(rangedAttackPrefab, transform.position, CalculateRotationToPlayer());
                lastAttackTime = Time.time;
            }
        }

        private void AoEAttack()
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                Instantiate(aoeAttackPrefab, transform.position, Quaternion.identity);
                lastAttackTime = Time.time;
            }
        }

        private Quaternion CalculateRotationToPlayer()
        {
            Vector2 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}