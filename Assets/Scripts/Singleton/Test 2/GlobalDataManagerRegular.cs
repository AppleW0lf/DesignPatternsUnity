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
        public List<MyComplexData> complexDataList = new List<MyComplexData>();

        // Размер данных
        public int dataSize = 1000;

        private void Awake()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            complexDataList = new List<MyComplexData>(dataSize);
            for (int i = 0; i < dataSize; i++)
            {
                complexDataList.Add(new MyComplexData());
            }
        }

        public List<MyComplexData> GetData()
        {
            return complexDataList;
        }
    }
}