using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVVM.MVVM
{
    public class PerformanceTest : MonoBehaviour
    {
        [SerializeField] private CounterViewModel _mvvmSystem;
        [SerializeField] private SpaghettiCounter _spaghettiSystem;
        [SerializeField] private int _iterations = 10000;

        private void Start()
        {
            TestMVVM();
            TestSpaghetti();
        }

        private void TestMVVM()
        {
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < _iterations; i++)
                _mvvmSystem.Increment();

            stopwatch.Stop();
            UnityEngine.Debug.Log($"MVVM время: {stopwatch.ElapsedMilliseconds} мс");
        }

        private void TestSpaghetti()
        {
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < _iterations; i++)
                _spaghettiSystem.IncrementCount();

            stopwatch.Stop();
            UnityEngine.Debug.Log($"Spaghetti время: {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}