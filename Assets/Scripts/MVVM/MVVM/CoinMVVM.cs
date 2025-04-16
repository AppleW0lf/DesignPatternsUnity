using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVVM.MVVM
{
    public class CoinMVVM : MonoBehaviour
    {
        public TreasureCollectorView collectorView;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                collectorView.CollectCoin(gameObject);
            }
        }
    }
}