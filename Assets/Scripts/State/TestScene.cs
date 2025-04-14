using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.State
{
    public class TestScene : MonoBehaviour
    {
        public GameObject playerPrefab; // Префаб объекта игрока
        public int numberOfPlayers = 100;

        private void Start()
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Vector3 position = new Vector3(UnityEngine.Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0);
                Instantiate(playerPrefab, position, Quaternion.identity);
            }
        }
    }
}