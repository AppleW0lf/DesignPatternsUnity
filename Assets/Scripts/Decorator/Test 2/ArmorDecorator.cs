using Assets.Scripts.Decorator.Test2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Decorator.Test_2
{
    public class ArmorDecorator : HealthSystemDecorator
    {
        private float _armor;

        public ArmorDecorator(IHealthSystem wrappedHealthSystem, float armor) : base(wrappedHealthSystem)
        {
            _armor = armor;
        }

        public override float TakeDamage(float damage)
        {
            float damageAfterArmor = damage - _armor;
            damageAfterArmor = Mathf.Max(damageAfterArmor, 0); // Не допускаем отрицательный урон
            return base.TakeDamage(damageAfterArmor);
        }
    }
}