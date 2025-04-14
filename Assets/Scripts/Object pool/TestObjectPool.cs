using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TestObjectPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int numBullets = 1000;
    public bool warmUp = true;

    private BulletPool bulletPool; // Ссылка на BulletPool

    private void Start()
    {
        bulletPool = FindFirstObjectByType<BulletPool>(); // Поиск BulletPool в сцене

        if (bulletPool == null)
        {
            Debug.LogError("BulletPool не найден в сцене! Отключение теста с Object Pool.");
            enabled = false; // Отключаем скрипт, чтобы не было ошибок
            return;
        }

        if (warmUp)
        {
            Debug.Log("Выполняется разогрев (с Object Pool)...");
            WarmUp(numBullets);
        }
        TestPerformance();
    }

    private void WarmUp(int numBullets)
    {
        // Разогрев с Object Pool
        List<PooledObject> usedBullets = new List<PooledObject>(); // Храним использованные пули

        for (int i = 0; i < numBullets; i++)
        {
            PooledObject bullet = bulletPool.GetPooledBullet();
            if (bullet != null)
            {
                usedBullets.Add(bullet); // Записываем в список
            }
        }

        // Возвращаем в пул
        foreach (var bullet in usedBullets)
        {
            if (bullet != null)
            {
                bulletPool.ReturnToPool(bullet);
            }
        }
        usedBullets.Clear(); // Очищаем список

        Resources.UnloadUnusedAssets(); // Освобождаем ресурсы после разогрева
        System.GC.Collect(); // Запускаем сборку мусора после разогрева
        Debug.Log("Разогрев завершен (с Object Pool).");
    }

    private void TestPerformance()
    {
        Debug.Log("Начинаем тест производительности (с Object Pool)...");
        long withPoolTime = TestWithPool(numBullets);
        Debug.Log($"С Object Pool: {withPoolTime} ms");
        Debug.Log("Тест производительности завершен (с Object Pool).");
    }

    private long TestWithPool(int numBullets)
    {
        if (bulletPool == null)
        {
            Debug.LogError("BulletPool не найден в сцене!");
            return -1;
        }

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        List<PooledObject> usedBullets = new List<PooledObject>(); // Храним использованные пули

        for (int i = 0; i < numBullets; i++)
        {
            PooledObject bullet = bulletPool.GetPooledBullet();
            if (bullet != null)
            {
                usedBullets.Add(bullet); // Записываем в список
            }
        }

        // Возвращаем в пул
        foreach (var bullet in usedBullets)
        {
            if (bullet != null)
            {
                bulletPool.ReturnToPool(bullet);
            }
        }
        usedBullets.Clear(); // Очищаем список

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}