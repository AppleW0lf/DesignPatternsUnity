using Assets.Scripts.State.GoodExample;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PerformanceTestState : MonoBehaviour
{
    public GameObject playerPrefab; // Префаб объекта игрока
    public int numberOfPlayers = 100;
    public int numIterations = 1000; // Количество итераций для теста
    public bool warmUp = true;

    private void Start()
    {
        if (warmUp)
        {
            Debug.Log("Выполняется разогрев (с State Pattern)...");
            WarmUp();
        }
        //TestPerformance();
    }

    private void CreatePlayers()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0);
            Instantiate(playerPrefab, position, Quaternion.identity);
        }
    }

    private void WarmUp()
    {
        // Выполняем несколько итераций для "разогрева"
        // Создаем игроков перед разогревом
        CreatePlayers();
        //Player[] players = playerPrefab.GetComponentsInChildren<Player>();
        Player[] players = playerPrefab.GetComponents<Player>();

        if (players == null || players.Length == 0)
        {
            Debug.LogError("Player не найден в сцене!");
            return;
        }
        for (int i = 0; i < numIterations; i++)
        {
            foreach (Player player in players)
            {
                if (player == null) Debug.Log("Player is null");
                player.TransitionTo(new RunningState());

                /* if (player == null) continue;
                 // Эмулируем смену состояний
                 if (i % 5 == 0) player.TransitionTo(new IdleState());
                 else if (i % 5 == 1) player.TransitionTo(new RunningState());
                 else if (i % 5 == 2) player.TransitionTo(new JumpingState());
                 else if (i % 5 == 3) player.TransitionTo(new CrouchingState());
                 else player.TransitionTo(new AttackingState());*/

                // Обновляем состояние
                player.currentState?.Update(player);
            }
        }
        // Уничтожаем игроков после разогрева
        /*foreach (Player player in players)
        {
            if (player != null)
                Destroy(player.gameObject);
        }*/
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
        Debug.Log("Разогрев завершен (с State Pattern).");
    }

    private void TestPerformance()
    {
        Debug.Log("Начинаем тест производительности (с State Pattern)...");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Создаем игроков для теста
        CreatePlayers();
        Player[] players = FindObjectsByType<Player>(FindObjectsSortMode.None); // Находим всех игроков в сцене

        if (players == null || players.Length == 0)
        {
            Debug.LogError("Player не найден в сцене!");
            return;
        }
        for (int i = 0; i < numIterations; i++)
        {
            foreach (Player player in players)
            {
                /* if (player == null) continue;
                 // Эмулируем смену состояний
                 if (i % 5 == 0) player.TransitionTo(new IdleState());
                 else if (i % 5 == 1) player.TransitionTo(new RunningState());
                 else if (i % 5 == 2) player.TransitionTo(new JumpingState());
                 else if (i % 5 == 3) player.TransitionTo(new CrouchingState());
                 else player.TransitionTo(new AttackingState());
                 // Обновляем состояние
                 player.currentState?.Update(player);*/
            }
        }

        stopwatch.Stop();
        Debug.Log($"С State Pattern: {stopwatch.ElapsedMilliseconds} ms");

        // Уничтожаем игроков после теста
        foreach (Player player in players)
        {
            if (player != null)
                Destroy(player.gameObject);
        }
    }
}