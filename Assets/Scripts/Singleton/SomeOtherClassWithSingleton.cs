using UnityEngine;

public class SomeOtherClassWithSingleton: MonoBehaviour
{
    void Update()
    {
        // Вызываем методы GameManager, каждый кадр.
        for (int i = 0; i < 1000; i++)
        {
            //GameManagerWithSingleton.Instance.ToString();
            GameManagerWithSingleton.Instance.IncreaseScore(1);
            GameManagerWithSingleton.Instance.AddCoins(1);
        }
        GameManagerWithSingleton.Instance.SomeMethod();
    }

}
