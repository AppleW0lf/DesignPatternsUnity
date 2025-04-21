using Assets.Scripts.Decorator.Test2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Decorator.Test_2
{
    public class HealthSystemWithoutDecorator : IHealthSystem
    {
        private float _maxHealth;
        private float _currentHealth;
        private float _armor;
        private float _damageResistance;

        public HealthSystemWithoutDecorator(float maxHealth, float armor, float damageResistance)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
            _armor = armor;
            _damageResistance = damageResistance;
        }

        public float TakeDamage(float damage)
        {
            float damageAfterArmor = damage - _armor;
            damageAfterArmor = Mathf.Max(damageAfterArmor, 0);

            float damageAfterResistance = damageAfterArmor * (1 - _damageResistance);
            damageAfterResistance = Mathf.Max(damageAfterResistance, 0);

            _currentHealth -= damageAfterResistance;
            _currentHealth = Mathf.Max(_currentHealth, 0);
            return _currentHealth;
        }

        public float GetCurrentHealth()
        {
            return _currentHealth;
        }
    }
}