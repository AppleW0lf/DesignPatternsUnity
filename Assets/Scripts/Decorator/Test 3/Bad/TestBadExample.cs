using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Decorator.Test3.Bad
{
    public class TestBadExample : MonoBehaviour
    {
        public PlayerDamageController playerDamageController; // Ссылка на PlayerDamageController
        public int numberOfFixedDamageComponents = 1000; // Количество FixedValue компонентов
        public int numberOfPercentBonusComponents = 1000; // Количество PercentBonus компонентов
        public float fixedDamageValue = 10f; // Значение FixedValue компонента
        public float percentBonusValue = 0.1f; // Значение PercentBonus компонента (0.1f = 10%)
        public int numberOfIterations = 100;

        private void Start()
        {
            if (playerDamageController == null)
            {
                Debug.LogError("Please assign the PlayerDamageController in the Inspector!");
                return;
            }

            TestDamageCalculationPerformance();
        }

        private void TestDamageCalculationPerformance()
        {
            // 1. Prepare: Add damage components BEFORE timing
            AddDamageComponents(numberOfFixedDamageComponents, numberOfPercentBonusComponents);

            // 2. Measure: Time the damage calculation ACROSS MULTIPLE ITERATIONS
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            float finalDamage = 0; // Объявляем finalDamage здесь, чтобы использовать его после цикла
            for (int i = 0; i < numberOfIterations; i++)
            {
                finalDamage = playerDamageController.GetDamageValue(); // Run the calculation repeatedly
            }

            stopwatch.Stop();

            // 3. Report: Print the result using Ticks for higher precision
            long elapsedTicks = stopwatch.ElapsedTicks;
            double elapsedMilliseconds = (double)elapsedTicks / Stopwatch.Frequency * 1000.0;

            Debug.Log($"Damage calculation with {numberOfFixedDamageComponents} fixed and {numberOfPercentBonusComponents} percent bonus components: {elapsedMilliseconds} ms for {numberOfIterations} iterations, Final Damage: {finalDamage}");
            // RemoveDamageComponents(numberOfFixedDamageComponents, numberOfPercentBonusComponents); // Implement if you want to run the test multiple times
        }

        private void AddDamageComponents(int fixedCount, int percentCount)
        {
            // Add Fixed Damage components
            for (int i = 0; i < fixedCount; i++)
            {
                playerDamageController.AddFixedDamage(fixedDamageValue);
            }

            // Add Percent Bonus damage components
            for (int i = 0; i < percentCount; i++)
            {
                playerDamageController.AddPercentBonusDamage(percentBonusValue);
            }
        }
    }
}