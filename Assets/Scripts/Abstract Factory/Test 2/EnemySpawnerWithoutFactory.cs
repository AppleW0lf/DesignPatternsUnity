using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abstract_Factory.Test_2
{
    public class EnemySpawnerWithoutFactory : MonoBehaviour
    {
        public GameObject planePrefab;
        public GameObject birdPrefab;
        public GameObject tankPrefab;
        public GameObject soldierPrefab;

        public Transform spawnPoint;

        public Enemy SpawnEnemy(string enemyType)
        {
            GameObject enemyGO = null;
            Enemy enemy = null;

            switch (enemyType)
            {
                case "Plane":
                    enemyGO = Instantiate(planePrefab, spawnPoint.position, Quaternion.identity);
                    enemy = enemyGO.GetComponent<Plane>();
                    if (enemy != null)
                        (enemy as Plane).Initialize(100f, 5f, 2f);
                    break;

                case "Bird":
                    enemyGO = Instantiate(birdPrefab, spawnPoint.position, Quaternion.identity);
                    enemy = enemyGO.GetComponent<Bird>();
                    if (enemy != null)
                        (enemy as Bird).Initialize(50f, 7f, 3f);
                    break;

                case "Tank":
                    enemyGO = Instantiate(tankPrefab, spawnPoint.position, Quaternion.identity);
                    enemy = enemyGO.GetComponent<Tank>();
                    if (enemy != null)
                        (enemy as Tank).Initialize(200f, 3f);
                    break;

                case "Soldier":
                    enemyGO = Instantiate(soldierPrefab, spawnPoint.position, Quaternion.identity);
                    enemy = enemyGO.GetComponent<Soldier>();
                    if (enemy != null)
                        (enemy as Soldier).Initialize(75f, 4f);
                    break;

                default:
                    Debug.LogError("Unknown enemy type: " + enemyType);
                    return null;
            }

            return enemy;
        }
    }
}