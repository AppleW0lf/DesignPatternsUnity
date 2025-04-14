using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Singleton.Test_2
{
    public class TestObjectCreating : MonoBehaviour
    {
        public interface IDataProvider  // интерфейс для работы с данными
        {
            int GetData();
        }

        public IDataProvider dataManager;

        private void Start()
        {
            // Просто используем ссылку на DataManager, чтобы убедиться, что она установлена.
            int someValue = dataManager.GetData();
        }
    }
}