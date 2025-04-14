using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts.ECS.NoECS
{
    public class Spawner : MonoBehaviour
    {
        public int iterations = 1000;
        public GameObject square;
        public Transform spawnpoint;

        private void Start()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                GameObject.Instantiate(square, spawnpoint);
            }
            stopwatch.Stop();
            UnityEngine.Debug.Log($"NoECS Time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}