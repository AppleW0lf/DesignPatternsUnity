using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Adapter
{
    using System.Diagnostics;
    using Unity.Entities.UniversalDelegates;
    using UnityEngine;
    using UnityEngine.Profiling;
    using Debug = UnityEngine.Debug;

    public class PerformanceTest : MonoBehaviour
    {
        public int numberOfCharacters = 1000;
        public float testDuration = 5f;
        public GameObject characterPrefab;
        public bool useAdapter = true; // Определяет, какой тест запускать

        private GameObject[] _characters;
        private AdvancedMovementLibrary _advancedMover = new AdvancedMovementLibrary(); // Один экземпляр
        private Stopwatch _stopwatch = new Stopwatch();

        private void Start()
        {
            _characters = new GameObject[numberOfCharacters]; // Создаем массив

            // Предварительное создание объектов (вне тайминга)
            for (int i = 0; i < numberOfCharacters; i++)
            {
                _characters[i] = Instantiate(characterPrefab);
                _characters[i].transform.position = Random.insideUnitSphere * 10;
            }

            // Запуск теста через заданное время (чтобы дать сцене стабилизироваться)
            Invoke("RunTest", 1f);
        }

        private void RunTest()
        {
            _stopwatch.Start();
            Profiler.BeginSample(useAdapter ? "WithAdapter" : "WithoutAdapter");

            if (useAdapter)
            {
                TestWithAdapter();
            }
            else
            {
                TestWithoutAdapter();
            }

            _stopwatch.Stop();
            Profiler.EndSample();
            long elapsedTicks = _stopwatch.ElapsedTicks;
            double elapsedMilliseconds = (double)elapsedTicks / Stopwatch.Frequency * 1000.0;

            Debug.Log($"Test {(useAdapter ? "With" : "Without")} Adapter: {elapsedMilliseconds} ms");
        }

        private void TestWithAdapter()
        {
            for (int i = 0; i < numberOfCharacters; i++)
            {
                // Создаем адаптер для каждого персонажа
                AdvancedMovementAdapter adapter = new AdvancedMovementAdapter(_advancedMover, _characters[i].GetComponent<Rigidbody2D>());
                adapter.Move(new Vector2(0.5f, 0.5f));
            }
        }

        private void TestWithoutAdapter()
        {
            for (int i = 0; i < numberOfCharacters; i++)
            {
                _advancedMover.MoveCharacter(_characters[i].GetComponent<Rigidbody2D>(), 0.5f, 0.5f);
            }
        }
    }
}