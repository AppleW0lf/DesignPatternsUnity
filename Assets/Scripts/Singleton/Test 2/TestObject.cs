using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Singleton.Test_2
{
    public class TestObject : MonoBehaviour
    {
        public interface IDataProvider
        {
            int GetData();
        }

        public IDataProvider dataProvider;

        public void AccessData()
        {
            int someValue = dataProvider.GetData();
        }
    }
}