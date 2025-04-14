using System.Diagnostics;
using UnityEngine;

public class WithoutCommandPattern : MonoBehaviour
{
    public Transform objectToMove;
    public int iterations = 100000;

    private void Start()
    {
        var stopwatch = Stopwatch.StartNew();

        // Прямой вызов без паттерна
        for (int i = 0; i < iterations; i++)
        {
            objectToMove.position += new Vector3(
                    Vector2.right.x,
                    Vector2.right.y,
                    0) * Time.deltaTime;
        }

        stopwatch.Stop();
        UnityEngine.Debug.Log($"Direct execution time: {stopwatch.ElapsedMilliseconds} ms");
    }
}