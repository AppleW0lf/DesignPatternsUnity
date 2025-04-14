using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Abstract_Factory.Test_2
{
    public abstract class GroundEnemy : Enemy
    {
        private void Update()
        {
            Move();
        }
    }
}