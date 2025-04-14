using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abstract_Factory.Test_2
{
    public class EnemySpawnerWithFactory : MonoBehaviour
    {
        public IAbstractFactory factory;
        public Transform spawnPoint;

        public Enemy SpawnEnemy()
        {
            if (factory == null)
            {
                Debug.LogError("Factory is not assigned!");
                return null;
            }

            Enemy enemy = factory.CreateEnemy();
            if (enemy != null)
            {
                enemy.transform.position = spawnPoint.position;
            }

            return enemy;
        }
    }
}