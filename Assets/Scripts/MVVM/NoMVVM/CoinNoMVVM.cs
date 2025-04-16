using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVVM.NoMVVM
{
    public class CoinNoMVVM : MonoBehaviour
    {
        public TreasureCollectorNoMVVM collector;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                collector.CollectCoin(gameObject);
            }
        }
    }
}