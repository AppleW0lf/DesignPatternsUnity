using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy.Test_1
{
    public abstract class AttackStrategy : MonoBehaviour
    {
        public float attackCooldown = 1f;
        protected float lastAttackTime;

        public abstract void Attack(Transform attacker, GameObject player);

        protected bool CanAttack()
        {
            return Time.time - lastAttackTime >= attackCooldown;
        }
    }
}