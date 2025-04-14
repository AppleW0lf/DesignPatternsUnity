using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PerformanceTestObserver : MonoBehaviour
{
    public PlayerWithObserver player;
    public float damageAmount = 10f;
    public int numDamageEvents = 1000;
    public bool warmUp = true;
    public KeyCode damageKey = KeyCode.Space; // Кнопка по умолчанию - Пробел

    private HurtEffectObserverWithEvent effectObserver;
    private UIHealthBarObserverWithEvent healthBar;
    private SoundEffectObserverWithEvent soundObserver;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerWithObserver>();

        if (player == null)
        {
            Debug.LogError("PlayerWithObserver не найден в сцене!  Отключение теста с Observer.");
            enabled = false; // Отключаем скрипт
            return;
        }

        // Найдем Observer-ы
        healthBar = FindFirstObjectByType<UIHealthBarObserverWithEvent>();
        soundObserver = FindFirstObjectByType<SoundEffectObserverWithEvent>();
        effectObserver = FindFirstObjectByType<HurtEffectObserverWithEvent>();
        if (healthBar != null) { healthBar.Initialize(player); }
        if (soundObserver != null) { soundObserver.Initialize(player); }
        if (effectObserver != null) { effectObserver.Initialize(player); }

        if (warmUp)
        {
            Debug.Log("Выполняется разогрев (с Observer)...");
            WarmUp(numDamageEvents);
        }
        TestPerformance();
    }

    private void WarmUp(int numDamageEvents)
    {
        // Разогрев с Observer
        for (int i = 0; i < numDamageEvents; i++)
        {
            player.TakeDamage(damageAmount);
        }
        player.health = 100f; // Восстанавливаем здоровье после разогрева

        Resources.UnloadUnusedAssets();
        System.GC.Collect();
        Debug.Log("Разогрев завершен (с Observer).");
    }

    private void TestPerformance()
    {
        Debug.Log("Начинаем тест производительности (с Observer)...");
        long withObserverTime = TestWithObserver(numDamageEvents);
        Debug.Log($"С Observer: {withObserverTime} ms");
        Debug.Log("Тест производительности завершен (с Observer).");
    }

    private long TestWithObserver(int numDamageEvents)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < numDamageEvents; i++)
        {
            player.TakeDamage(damageAmount);
        }

        stopwatch.Stop();
        player.health = 100f; // Восстанавливаем здоровье после теста
        return stopwatch.ElapsedMilliseconds;
    }
}