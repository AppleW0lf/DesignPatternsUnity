using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MVP_Test2.MVP
{
    public class EnemyModel
    {
        public event Action<EnemyModel> OnDeath;

        private int _health = 30;

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0) OnDeath?.Invoke(this);
        }
    }
}