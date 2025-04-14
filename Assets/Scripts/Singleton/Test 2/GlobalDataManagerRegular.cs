using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Singleton.Test_2
{
    public class GlobalDataManagerRegular : MonoBehaviour,
        TestObject.IDataProvider
    {
        public int someData = 42;

        public int GetData()
        {
            return someData;
        }
    }
}