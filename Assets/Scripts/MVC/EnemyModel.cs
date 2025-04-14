using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MVC
{
    public class EnemyModel
    {
        private int _health;

        public int Health
        {
            get => _health;
            private set
            {
                _health = value;
                OnHealthChanged?.Invoke(_health);
            }
        }

        public event Action<int> OnHealthChanged;

        public EnemyModel(int maxHealth)
        {
            Health = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - damage);
        }
    }
}