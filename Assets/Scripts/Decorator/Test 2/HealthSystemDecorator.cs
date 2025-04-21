using Assets.Scripts.Decorator.Test2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Decorator.Test_2
{
    public abstract class HealthSystemDecorator : IHealthSystem
    {
        protected IHealthSystem _wrappedHealthSystem;

        public HealthSystemDecorator(IHealthSystem wrappedHealthSystem)
        {
            _wrappedHealthSystem = wrappedHealthSystem;
        }

        public virtual float TakeDamage(float damage)
        {
            return _wrappedHealthSystem.TakeDamage(damage);
        }

        public virtual float GetCurrentHealth()
        {
            return _wrappedHealthSystem.GetCurrentHealth();
        }
    }
}