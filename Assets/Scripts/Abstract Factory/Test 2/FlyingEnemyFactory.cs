using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abstract_Factory.Test_2
{
    public class FlyingEnemyFactory : MonoBehaviour, IAbstractFactory
    {
        public GameObject planePrefab;
        public GameObject birdPrefab;

        public enum FlyingEnemyType
        { Plane, Bird }

        public FlyingEnemyType enemyType;

        public Enemy CreateEnemy()
        {
            GameObject enemyGO = null;
            Enemy enemy = null;

            switch (enemyType)
            {
                case FlyingEnemyType.Plane:
                    enemyGO = Instantiate(planePrefab, Vector3.zero, Quaternion.identity);
                    enemy = enemyGO.GetComponent<Plane>();
                    if (enemy != null)
                        (enemy as Plane).Initialize(100f, 5f, 2f);
                    break;

                case FlyingEnemyType.Bird:
                    enemyGO = Instantiate(birdPrefab, Vector3.zero, Quaternion.identity);
                    enemy = enemyGO.GetComponent<Bird>();
                    if (enemy != null)
                        (enemy as Bird).Initialize(50f, 7f, 3f);
                    break;

                default:
                    Debug.LogError("Unknown flying enemy type.");
                    return null;
            }

            return enemy;
        }
    }
}