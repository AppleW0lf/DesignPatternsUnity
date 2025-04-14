using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abstract_Factory.Test_2
{
    public class GroundEnemyFactory : MonoBehaviour, IAbstractFactory
    {
        public GameObject tankPrefab;
        public GameObject soldierPrefab;

        public enum GroundEnemyType
        { Tank, Soldier }

        public GroundEnemyType enemyType;

        public Enemy CreateEnemy()
        {
            GameObject enemyGO = null;
            Enemy enemy = null;

            switch (enemyType)
            {
                case GroundEnemyType.Tank:
                    enemyGO = Instantiate(tankPrefab, Vector3.zero, Quaternion.identity);
                    enemy = enemyGO.GetComponent<Tank>();
                    if (enemy != null)
                        (enemy as Tank).Initialize(200f, 3f);
                    break;

                case GroundEnemyType.Soldier:
                    enemyGO = Instantiate(soldierPrefab, Vector3.zero, Quaternion.identity);
                    enemy = enemyGO.GetComponent<Soldier>();
                    if (enemy != null)
                        (enemy as Soldier).Initialize(75f, 4f);
                    break;

                default:
                    Debug.LogError("Unknown ground enemy type.");
                    return null;
            }

            return enemy;
        }
    }
}