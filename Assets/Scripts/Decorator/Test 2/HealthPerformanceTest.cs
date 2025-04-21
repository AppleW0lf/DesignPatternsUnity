using Assets.Scripts.Decorator.Test2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Decorator.Test_2
{
    public class HealthPerformanceTest : MonoBehaviour
    {
        public int iterations = 100000;
        public float damageAmount = 10f;
        public float maxHealth = 100f;
        public float armor = 5f;
        public float damageResistance = 0.2f;

        private void Start()
        {
            TestPerformance();
        }

        private void TestPerformance()
        {
            // *** БЕЗ Decorator ***
            /*Stopwatch swWithout = Stopwatch.StartNew();
            IHealthSystem healthSystemWithout = new HealthSystemWithoutDecorator(maxHealth, armor, damageResistance);
            for (int i = 0; i < iterations; i++)
            {
                healthSystemWithout.TakeDamage(damageAmount);
                healthSystemWithout.GetCurrentHealth(); // Добавляем вызов, чтобы убедиться, что GetCurrentHealth тоже влияет на результат
            }
            swWithout.Stop();
            Debug.Log($"Without Decorator: {swWithout.ElapsedMilliseconds} ms.  Health: {healthSystemWithout.GetCurrentHealth()}")*/
            ;

            // *** С Decorator ***
            Stopwatch swWith = Stopwatch.StartNew();
            IHealthSystem baseHealthSystem = new BaseHealthSystem(maxHealth);
            IHealthSystem healthSystemWith = new DamageResistanceDecorator(new ArmorDecorator(baseHealthSystem, armor), damageResistance);
            for (int i = 0; i < iterations; i++)
            {
                healthSystemWith.TakeDamage(damageAmount);
                healthSystemWith.GetCurrentHealth(); // Добавляем вызов, чтобы убедиться, что GetCurrentHealth тоже влияет на результат
            }
            swWith.Stop();
            Debug.Log($"With Decorator: {swWith.ElapsedMilliseconds} ms. Health: {healthSystemWith.GetCurrentHealth()}");
        }
    }
}