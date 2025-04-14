using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TestForDecorator : MonoBehaviour
{
    public PlayerDamageController playerDamageController;
    public int numberOfFixedDamageComponents = 1000;
    public int numberOfPercentBonusComponents = 1000;
    public float fixedDamageValue = 10f;
    public float percentBonusValue = 0.1f;
    public int numberOfIterations = 100;

    private List<DamageComponent> _damageComponents = new List<DamageComponent>();

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

        float finalDamage = 0;
        for (int i = 0; i < numberOfIterations; i++)
        {
            finalDamage = playerDamageController.GetDamageValue();
        }

        stopwatch.Stop();

        // 3. Report: Print the result using Ticks for higher precision
        long elapsedTicks = stopwatch.ElapsedTicks;
        double elapsedMilliseconds = (double)elapsedTicks / Stopwatch.Frequency * 1000.0;

        Debug.Log($"Damage calculation with {numberOfFixedDamageComponents} fixed and {numberOfPercentBonusComponents} percent bonus decorators: {elapsedMilliseconds} ms for {numberOfIterations} iterations, Final Damage: {finalDamage}");
    }

    private void AddDamageComponents(int fixedCount, int percentCount)
    {
        for (int i = 0; i < fixedCount; i++)
        {
            playerDamageController.AddFixedDamage(fixedDamageValue);
        }

        for (int i = 0; i < percentCount; i++)
        {
            playerDamageController.AddPercentBonusDamage(percentBonusValue);
        }
    }
}