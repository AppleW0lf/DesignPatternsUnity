using UnityEngine;

namespace Assets.Scripts.Decorator.Test3.Bad
{
    public class DamageComponent
    {
        public readonly DamageComponentType DamageComponentType;
        public readonly float Value;

        public DamageComponent(DamageComponentType damageComponentType, float value)
        {
            DamageComponentType = damageComponentType;
            Value = value;
        }
    }
}