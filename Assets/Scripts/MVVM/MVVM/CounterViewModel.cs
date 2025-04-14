using Assets.Scripts.MVVM.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVVM.MVVM
{
    public class CounterViewModel : MonoBehaviour
    {
        [SerializeField] private CounterModel _model;

        public event System.Action<int> OnCountUpdated;

        private void OnEnable()
        {
            // Подписываемся на событие модели
            if (_model != null)
                _model.OnCountChanged += HandleCountChanged;
        }

        private void OnDisable()
        {
            // Отписываемся при выключении
            if (_model != null)
                _model.OnCountChanged -= HandleCountChanged;
        }

        private void HandleCountChanged(int newCount)
        {
            // Пробрасываем значение во View
            OnCountUpdated?.Invoke(newCount);
        }

        public void Increment()
        {
            if (_model != null)
                _model.Increment();
        }
    }
}