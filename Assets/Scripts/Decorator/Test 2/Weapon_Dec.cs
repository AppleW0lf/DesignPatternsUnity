using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Decorator.Test_2
{
    using UnityEngine;

    public abstract class Weapon_Dec
    {
        public abstract void Attack();
    }

    public class Sword : Weapon_Dec
    {
        public override void Attack()
        {
            Debug.Log("Swing sword");
        }
    }

    public abstract class WeaponDecorator : Weapon_Dec
    {
        protected Weapon_Dec _weapon;

        public WeaponDecorator(Weapon_Dec weapon)
        {
            _weapon = weapon;
        }

        public override void Attack()
        {
            if (_weapon != null)
            {
                _weapon.Attack();
            }
        }
    }

    public class FireEffect : WeaponDecorator
    {
        public FireEffect(Weapon_Dec weapon) : base(weapon)
        {
        }

        public override void Attack()
        {
            base.Attack();
            Debug.Log("Add fire effect");
        }
    }

    public class PoisonEffect : WeaponDecorator
    {
        public PoisonEffect(Weapon_Dec weapon) : base(weapon)
        {
        }

        public override void Attack()
        {
            base.Attack();
            Debug.Log("Add poison effect");
        }
    }
}