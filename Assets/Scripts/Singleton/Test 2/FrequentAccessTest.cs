using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Singleton.Test_2
{
    public class FrequentAccessTest : MonoBehaviour
    {
        public int numberOfObjects = 100;
        public int numberOfFrames = 100;
        public bool useSingleton = true;
        public GameObject testObjectPrefab;
        private Stopwatch stopwatch = new Stopwatch();
        private TestObject[] testObjects;

        private void Start()
        {
            testObjects = new TestObject[numberOfObjects];
            for (int i = 0; i < numberOfObjects; i++)
            {
                GameObject obj = Instantiate(testObjectPrefab);
                testObjects[i] = obj.GetComponent<TestObject>();
            }

            if (useSingleton)
            {
                stopwatch.Start();
                for (int i = 0; i < numberOfObjects; i++)
                {
                    testObjects[i].dataProvider = GlobalDataManager.Instance; // Доступ через Singleton
                }
            }
            else
            {
                stopwatch.Start();
                // Создаем обычный объект для передачи данных
                GameObject dataObject = new GameObject("RegularDataManager");
                GlobalDataManagerRegular regularDataManager = dataObject.AddComponent<GlobalDataManagerRegular>();

                for (int i = 0; i < numberOfObjects; i++)
                {
                    testObjects[i].dataProvider = regularDataManager; // Доступ через обычный объект
                }
            }
        }

        private void Update()
        {
            Test();
        }

        private void Test()
        {
            if (numberOfFrames > 0)
            {
                numberOfFrames--;

                for (int i = 0; i < numberOfObjects; i++)
                {
                    testObjects[i].AccessData();
                }
            }
            else if (numberOfFrames == 0)
            {
                stopwatch.Stop();
                Debug.Log("Frequent Access - " + (useSingleton ? "Singleton" : "Regular Object") + ": " + stopwatch.ElapsedMilliseconds + " ms");
                enabled = false;
            }
        }
    }
}