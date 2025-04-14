using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy.Test_1
{
    public class RangeAttack : Attack
    {
        public float speed = 5f;

        private void Start()
        {
            GetComponent<Rigidbody2D>().linearVelocity = transform.right * speed; // Задаем направление движения
            base.Start();
        }
    }
}