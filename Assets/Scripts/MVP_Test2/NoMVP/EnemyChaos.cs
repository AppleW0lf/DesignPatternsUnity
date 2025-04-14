using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVP_Test2.NoMVP
{
    public class EnemyChaos : MonoBehaviour
    {
        public ChaosController controller;
        private int _health = 30;

        private void OnMouseDown()
        {
            _health -= 15;
            if (_health <= 0)
            {
                controller.EnemyKilled(gameObject);
                Destroy(gameObject);
            }
        }
    }
}