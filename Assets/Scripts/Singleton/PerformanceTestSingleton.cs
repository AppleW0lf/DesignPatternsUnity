using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PerformanceTestSingleton : MonoBehaviour
{
    public int numIterations = 10000; // Количество итераций для теста
    public bool warmUp = true;

    private void Start()
    {
        if (warmUp)
        {
            Debug.Log("Выполняется разогрев (с Singleton)...");
            WarmUp();
        }
        TestPerformance();
    }

    private void WarmUp()
    {
        // Выполняем несколько итераций для "разогрева"
        for (int i = 0; i < numIterations; i++)
        {
            GameManagerWithSingleton.Instance.IncreaseScore(1);
            GameManagerWithSingleton.Instance.AddCoins(1);
        }
        GameManagerWithSingleton.Instance.score = 0; // Сбрасываем значения
        GameManagerWithSingleton.Instance.coins = 100;
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
        Debug.Log("Разогрев завершен (с Singleton).");
    }

    private void TestPerformance()
    {
        Debug.Log("Начинаем тест производительности (с Singleton)...");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < numIterations; i++)
        {
            GameManagerWithSingleton.Instance.IncreaseScore(1);
            GameManagerWithSingleton.Instance.AddCoins(1);
        }

        stopwatch.Stop();
        Debug.Log($"С Singleton: {stopwatch.ElapsedMilliseconds} ms");
        Debug.Log($"Final Score (Singleton): {GameManagerWithSingleton.Instance.score}");

        GameManagerWithSingleton.Instance.score = 0; // Сбрасываем значения
        GameManagerWithSingleton.Instance.coins = 100;
    }
}