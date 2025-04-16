using Assets.Scripts.MVVM_Test3.MVVM;
using Assets.Scripts.MVVM_Test3.NoMVVM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.MVVM_Test3
{
    public class PerformanceTester : MonoBehaviour
    {
        public bool useMVVM = false;
        public TextEditorNoMVVM textEditorNoMVVM; // Ссылка на скрипт без MVVM
        public TextEditorView textEditorViewMVVM; // Ссылка на скрипт с MVVM
        public int iterations = 100; // Количество итераций
        public float delayBetweenChanges = 0.01f; // Задержка между изменениями
        private List<double> noMVVMTimes = new List<double>();
        private List<double> mvvmTimes = new List<double>();
        public string testText = "if (condition) { // comment\n  statement; } else { statement; }"; // Пример текста для тестирования

        private IEnumerator Start()
        {
            Debug.Log("Starting Performance Tests...");
            if (useMVVM)
            {
                Debug.Log("Testing MVVM...");
                yield return RunTestMVVM();
                double avgMVVM = CalculateAverage(mvvmTimes);
                Debug.Log("Average UI Update Time (MVVM): " + avgMVVM + " ms");
            }
            else
            {
                Debug.Log("Testing No MVVM...");
                yield return RunTestNoMVVM();
                double avgNoMVVM = CalculateAverage(noMVVMTimes);
                Debug.Log("Average UI Update Time (No MVVM): " + avgNoMVVM + " ms");
            }
        }

        private IEnumerator RunTestNoMVVM()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                textEditorNoMVVM.inputField.text = testText;
                textEditorNoMVVM.OnTextChanged(textEditorNoMVVM.inputField.text);
                yield return new WaitForSeconds(delayBetweenChanges);
                noMVVMTimes.Add(textEditorNoMVVM.updateTime);
            }
            stopwatch.Stop();
            Debug.Log($"No MVVM time {stopwatch.ElapsedMilliseconds}");
        }

        private IEnumerator RunTestMVVM()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                textEditorViewMVVM.inputField.text = testText;
                textEditorViewMVVM.UpdateHighlightedText(textEditorViewMVVM.inputField.text);
                yield return new WaitForSeconds(delayBetweenChanges);
                mvvmTimes.Add(textEditorViewMVVM.updateTime);
            }
            stopwatch.Stop();
            Debug.Log($"MVVM time {stopwatch.ElapsedMilliseconds}");
        }

        private double CalculateAverage(List<double> list)
        {
            double sum = 0;
            foreach (double time in list)
            {
                sum += time;
            }
            return sum / list.Count;
        }
    }
}