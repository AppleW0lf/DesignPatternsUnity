using UnityEngine;

public class GameManagerWithoutSingleton: MonoBehaviour
{
    public int currentLevel = 1;
    public int score = 0;
    public int coins = 100;

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }
    // Пример использования:
    public void SomeMethod()
    {
        Debug.Log($"Level: {currentLevel}, Score: {score}, Coins: {coins}");
    }

}
