using UnityEngine;

namespace Assets.Scripts.Decorator.Test2
{
    public interface IHealthSystem
    {
        float TakeDamage(float damage);

        float GetCurrentHealth();
    }
}