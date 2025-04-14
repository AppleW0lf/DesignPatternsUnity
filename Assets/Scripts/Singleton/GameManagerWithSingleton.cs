using UnityEditor.Overlays;
using UnityEngine;

public class GameManagerWithSingleton : MonoBehaviour
{
    public static GameManagerWithSingleton Instance { get; private set; }

    public int currentLevel = 1;
    public int score = 0;
    public int coins = 100;

    //public float[] someData;
    // Другие глобальные настройки и методы...
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Чтобы синглтон не уничтожался при загрузке сцен
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /* void Start()
     {
         someData = new float[10000];
         for (int i = 0; i < someData.Length; i++)
         {
             someData[i] = Random.value;
         }
     }*/
    /* void Update()
     {
         // Очень плохой пример, имитируем ресурсоёмкие операции
         for (int i = 0; i < 10000; i++)
         {
             Mathf.Sqrt(someData[Random.Range(0, someData.Length)]);
             Mathf.Sin(someData[Random.Range(0, someData.Length)]);
         }

         Debug.Log($"Current Frame Rate {1 / Time.deltaTime}");
     }*/

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