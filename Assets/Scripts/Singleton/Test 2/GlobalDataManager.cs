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
                }
                return _instance;
            }
        }

        public int someData = 42;

        public int GetData()
        {
            return someData;
        }
    }
}