using Assets.Scripts.Decorator.Test2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Decorator.Test_2
{
    public class BaseHealthSystem : IHealthSystem
    {
        private float _maxHealth;
        private float _currentHealth;

        public BaseHealthSystem(float maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        public float TakeDamage(float damage)
        {
            _currentHealth -= damage;
            _currentHealth = Mathf.Max(_currentHealth, 0);
            return _currentHealth;
        }

        public float GetCurrentHealth()
        {
            return _currentHealth;
        }
    }
}