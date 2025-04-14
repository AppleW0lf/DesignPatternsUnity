using UnityEngine;

public class SomeOtherClassWithoutSingleton: MonoBehaviour
{
    public GameManagerWithoutSingleton gameManager;
    void Start()
    {
        // Находим менеджера через GetComponent
        gameManager = FindFirstObjectByType<GameManagerWithoutSingleton>();
    }
    void Update()
    {
        // Вызываем методы GameManager, каждый кадр.
        for (int i = 0; i < 1000; i++)
        {
            gameManager.IncreaseScore(1);
            gameManager.AddCoins(1);
        }
        gameManager.SomeMethod();
    }
}
