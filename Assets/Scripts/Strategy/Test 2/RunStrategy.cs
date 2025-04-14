using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy.Test_2
{
    public class RunStrategy : IMoveStrategy
    {
        private float speed = 5f;

        public void Move(Transform transform)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}