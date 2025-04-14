using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Abstract_Factory.Test_2
{
    public class Plane : FlyingEnemy
    {
        public override void Initialize(float health, float speed, float altitude)
        {
            base.Initialize(health, speed, altitude);
            // Дополнительная инициализация для Plane
        }
    }
}