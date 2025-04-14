using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy.Test_1
{
    public class AoEAttack : Attack
    {
        public float radius = 3f;

        protected override void Update()
        {
            base.Update();
            Debug.Log("Range Attack");
            // Дополнительная логика для AoE атаки, например, расширение радиуса
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            // Игнорируем столкновения, AoE атака наносит урон всем в радиусе
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}