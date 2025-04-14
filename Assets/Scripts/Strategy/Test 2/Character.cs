using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy.Test_2
{
    public class Character : MonoBehaviour
    {
        private IMoveStrategy moveStrategy;

        public void SetMoveStrategy(IMoveStrategy strategy)
        {
            moveStrategy = strategy;
        }

        public void Update()
        {
            if (moveStrategy != null)
            {
                moveStrategy.Move(transform);
            }
        }
    }
}