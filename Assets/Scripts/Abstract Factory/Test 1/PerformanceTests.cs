using Examples.AbstractFactoryExample;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Abstract_Factory.Test_1
{
    public class PerformanceTests : MonoBehaviour
    {
        [SerializeField] private MainScript _factoryScript;
        [SerializeField] private MainScriptWithoutPattern _noFactoryScript;
        [SerializeField] private int _numberOfUnitsToCreate = 100;
        [SerializeField] private int _numberOfTestRuns = 10; // Количество повторных запусков тестов

        [SerializeField] private Button _testFactoryButton;
        [SerializeField] private Button _testNoFactoryButton;

        private List<long> _factoryTestResults = new List<long>();
        private List<long> _noFactoryTestResults = new List<long>();

        private void Start()
        {
            _testFactoryButton.onClick.AddListener(RunFactoryTest);
            _testNoFactoryButton.onClick.AddListener(RunNoFactoryTest);
            RunNoFactoryTest();
        }

        private void RunFactoryTest()
        {
            _factoryTestResults.Clear();
            Debug.Log("Starting Factory Test...");
            for (int i = 0; i < _numberOfTestRuns; i++)
            {
                long elapsedMilliseconds = TestFactory();
                _factoryTestResults.Add(elapsedMilliseconds);
                Debug.Log($"Factory Test Run {i + 1}: {elapsedMilliseconds} ms");
            }
            AnalyzeResults("Abstract Factory", _factoryTestResults);
        }

        private void RunNoFactoryTest()
        {
            _noFactoryTestResults.Clear();
            Debug.Log("Starting No Factory Test...");
            for (int i = 0; i < _numberOfTestRuns; i++)
            {
                long elapsedMilliseconds = TestNoFactory();
                _noFactoryTestResults.Add(elapsedMilliseconds);
                Debug.Log($"No Factory Test Run {i + 1}: {elapsedMilliseconds} ms");
            }
            AnalyzeResults("No Abstract Factory", _noFactoryTestResults);
        }

        private long TestFactory()
        {
            if (_factoryScript == null)
            {
                Debug.LogError("Factory script reference is missing!");
                return -1;
            }

            ClearGrid(_factoryScript);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < _numberOfUnitsToCreate; i++)
            {
                string team = GetRandomTeam();
                CreateUnit(_factoryScript, team); // Используем метод CreateUnit
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private long TestNoFactory()
        {
            if (_noFactoryScript == null)
            {
                Debug.LogError("No Factory script reference is missing!");
                return -1;
            }

            ClearGrid(_noFactoryScript);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < _numberOfUnitsToCreate; i++)
            {
                string team = GetRandomTeam();
                CreateUnit(_noFactoryScript, team); // Используем метод CreateUnit
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        // Helper method to randomly choose a team
        private string GetRandomTeam()
        {
            int randomNumber = Random.Range(0, 3);
            switch (randomNumber)
            {
                case 0: return "red";
                case 1: return "blue";
                case 2: return "green";
                default: return "red";
            }
        }

        private void CreateUnit(MonoBehaviour script, string team)
        {
            //Вызываем CreateKnight, CreateMage, CreateArcher по очереди
            int unitType = Random.Range(0, 3); // 0: Knight, 1: Mage, 2: Archer

            if (script is MainScript factoryScript)
            {
                switch (unitType)
                {
                    case 0:
                        factoryScript.CreateKnight(team);
                        break;

                    case 1:
                        factoryScript.CreateMage(team);
                        break;

                    case 2:
                        factoryScript.CreateArcher(team);
                        break;
                }
            }
            else if (script is MainScriptWithoutPattern noFactoryScript)
            {
                switch (unitType)
                {
                    case 0:
                        noFactoryScript.CreateKnight(team);
                        break;

                    case 1:
                        noFactoryScript.CreateMage(team);
                        break;

                    case 2:
                        noFactoryScript.CreateArcher(team);
                        break;
                }
            }
        }

        private void ClearGrid(MonoBehaviour script)
        {
            script.SendMessage("ClearGrid");
        }

        private void AnalyzeResults(string testName, List<long> results)
        {
            if (results.Count == 0)
            {
                Debug.LogWarning($"No results to analyze for {testName}.");
                return;
            }

            double average = 0;
            foreach (var result in results)
            {
                average += result;
            }
            average /= results.Count;

            double sumOfSquaresOfDifferences = 0;
            foreach (var result in results)
            {
                sumOfSquaresOfDifferences += Mathf.Pow((float)(result - average), 2);
            }
            double standardDeviation = Mathf.Sqrt((float)(sumOfSquaresOfDifferences / results.Count));

            Debug.Log($"--- {testName} Results ---");
            Debug.Log($"Average Time: {average} ms");
            Debug.Log($"Standard Deviation: {standardDeviation} ms");
        }
    }
}