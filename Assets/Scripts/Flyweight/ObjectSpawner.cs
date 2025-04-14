using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject prefabFly;
    [SerializeField] private int spawnCount = 50000;
    [SerializeField] private bool useFlyweight;

    private void Start()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        if (useFlyweight)
        {
            TestWithFlyWeight();
        }
        else
        {
            TestWithoutFlyWeight();
        }

        stopwatch.Stop();
        Debug.Log($"Test {(useFlyweight ? "With" : "Without")} Adapter: {stopwatch.ElapsedMilliseconds} ms");
    }

    private void TestWithoutFlyWeight()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(prefab);
        }
    }

    private void TestWithFlyWeight()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(prefabFly);
        }
    }
}