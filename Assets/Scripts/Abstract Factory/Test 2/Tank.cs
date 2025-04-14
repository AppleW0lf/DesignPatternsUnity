using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Abstract_Factory.Test_2
{
    public class Tank : GroundEnemy
    {
        public override void Initialize(float health, float speed)
        {
            base.Initialize(health, speed);
            // Дополнительная инициализация для Tank
        }
    }
}