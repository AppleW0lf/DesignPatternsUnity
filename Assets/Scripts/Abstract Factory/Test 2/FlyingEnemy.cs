using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abstract_Factory.Test_2
{
    public abstract class FlyingEnemy : Enemy
    {
        public float altitude;

        public virtual void Fly()
        {
            // Логика полета
            transform.Translate(Vector3.up * Mathf.Sin(Time.time) * altitude * Time.deltaTime);
        }

        private void Update()
        {
            Move();
            Fly();
        }

        public virtual void Initialize(float health, float speed, float altitude)
        {
            base.Initialize(health, speed);
            this.altitude = altitude;
        }
    }
}