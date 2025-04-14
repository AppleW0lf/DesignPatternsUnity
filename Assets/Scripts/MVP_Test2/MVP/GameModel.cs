using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MVP_Test2.MVP
{
    public class GameModel
    {
        public int Score { get; private set; }

        public void AddScore(int value) => Score += value;
    }
}