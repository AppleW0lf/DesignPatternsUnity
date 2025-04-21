using Assets.Scripts.Decorator.Test2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Decorator.Test_2
{
    public class DamageResistanceDecorator : HealthSystemDecorator
    {
        private float _damageResistance;

        public DamageResistanceDecorator(IHealthSystem wrappedHealthSystem, float damageResistance) : base(wrappedHealthSystem)
        {
            _damageResistance = damageResistance;
        }

        public override float TakeDamage(float damage)
        {
            float damageAfterResistance = damage * (1 - _damageResistance);
            damageAfterResistance = Mathf.Max(damageAfterResistance, 0);
            return base.TakeDamage(damageAfterResistance);
        }
    }
}