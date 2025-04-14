using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PerformanceTest : MonoBehaviour
{
    public int time = 100;

    private void Start()

    {
        TestWithoutDecorator();
        TestWithDecorator();
    }

    private void TestWithoutDecorator()
    {
        float startTime = Time.realtimeSinceStartup;

        Weapon sword = new FireSword();
        sword = new PoisonSword();
        for (int i = 0; i < time; i++)
        {
            sword.Attack();
        }

        float endTime = Time.realtimeSinceStartup;
        Debug.LogWarning("Time without Decorator: " + (endTime - startTime) + " seconds");
    }

    private void TestWithDecorator()
    {
        float startTime = Time.realtimeSinceStartup;

        Assets.Scripts.Decorator.Test_2.Weapon_Dec sword = new Assets.Scripts.Decorator.Test_2.Sword();
        sword = new Assets.Scripts.Decorator.Test_2.FireEffect(sword);
        sword = new Assets.Scripts.Decorator.Test_2.PoisonEffect(sword);
        for (int i = 0; i < time; i++)
        {
            sword.Attack();
        }

        float endTime = Time.realtimeSinceStartup;
        Debug.LogWarning("Time with Decorator: " + (endTime - startTime) + " seconds");
    }
}