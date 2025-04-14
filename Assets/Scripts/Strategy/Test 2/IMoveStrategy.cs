using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy.Test_2
{
    public interface IMoveStrategy
    {
        void Move(Transform transform);
    }
}