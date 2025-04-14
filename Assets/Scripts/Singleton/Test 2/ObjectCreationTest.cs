using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Singleton.Test_2
{
    public class ObjectCreationTest : MonoBehaviour
    {
        public int numberOfObjects = 1000;
        public bool useSingleton = true;

        private void Start()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numberOfObjects; i++)
            {
                GameObject obj = new GameObject("TestObject_" + i);
                var testObject = obj.AddComponent<TestObjectCreating>();

                // Присваиваем dataManager *до* Destroy, чтобы Start в TestObjectCreating успел выполниться
                if (useSingleton)
                {
                    // Explicitly cast to IDataProvider
                    testObject.dataManager = (TestObjectCreating.IDataProvider)GlobalDataManager.Instance;
                }
                else
                {
                    // Создаем обычный объект для передачи данных
                    GameObject dataObject = new GameObject("RegularDataManager");
                    GlobalDataManagerRegular regularDataManager = dataObject.AddComponent<GlobalDataManagerRegular>();
                    testObject.dataManager = (TestObjectCreating.IDataProvider)regularDataManager;
                    Destroy(dataObject); // Clean up the RegularDataManager
                }

                // Перемещаем Destroy вниз, но *после* присваивания dataManager
                Destroy(obj);
            }

            stopwatch.Stop();
            Debug.Log("Object Creation - " + (useSingleton ? "Singleton" : "Regular Object") + ": " + stopwatch.ElapsedMilliseconds + " ms");
        }
    }
}