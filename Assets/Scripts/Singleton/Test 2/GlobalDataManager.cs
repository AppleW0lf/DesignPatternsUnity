using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Singleton.Test_2
{
    public class GlobalDataManager : MonoBehaviour, TestObject.IDataProvider
    {
        private static GlobalDataManager _instance;

        public static GlobalDataManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    _instance = go.AddComponent<GlobalDataManager>();
                    go.name = _instance.GetType().Name;
                    //DontDestroyOnLoad(go);
                    _instance.InitializeData();
                }
                return _instance;
            }
        }

        public List<MyComplexData> complexDataList = new List<MyComplexData>();

        public int dataSize = 1000;

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