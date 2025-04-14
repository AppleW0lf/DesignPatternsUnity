using System.Collections.Generic;
using System;

public class GameModel
{
    public int Score { get; private set; } = 0;
    public List<TargetModel> Targets { get; } = new List<TargetModel>();

    public event Action<int> ScoreChanged;

    public GameModel(int numberOfTargets)
    {
        // Создаем цели
        for (int i = 0; i < numberOfTargets; i++)
        {
            float randomX = UnityEngine.Random.Range(-8f, 8f);
            float randomY = UnityEngine.Random.Range(-4f, -3f);
            Targets.Add(new TargetModel(randomX, randomY));
        }
    }

    public void CollectTarget()
    {
        Score++;
        ScoreChanged?.Invoke(Score); // Событие для уведомления View
    }
}