using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.MVP.WithMVP
{
    public class CounterPresenter : MonoBehaviour
    {
        [SerializeField]
        private CounterView _view;

        private CounterModel _model;
        private float _timer = 0f;
        private Stopwatch stopwatch;

        private void Awake()
        {
            _model = new CounterModel();
        }

        private void Start()
        {
            _view.OnResetButtonClicked += ResetCounter;
            _view.OnStopButtonClicked += StopCounter; // Подписываемся на кнопку "Стоп"
            UpdateView();
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        private void Update()
        {
            if (_model.IsRunning) // Проверяем, работает ли счетчик
            {
                _timer += Time.deltaTime;

                if (_timer >= 1f)
                {
                    _model.Increment();
                    UpdateView();
                    _timer = 0f;
                }
            }
        }

        private void ResetCounter()
        {
            _model.Reset();
            UpdateView();
            _view.ShowResetMessage();
        }

        private void StopCounter()
        {
            _model.Stop(); // Останавливаем счетчик в Model
            stopwatch.Stop(); // Останавливаем Stopwatch
            Debug.Log("MVP execution time: " + stopwatch.ElapsedMilliseconds + " ms");
            _view.DisableButtons();
        }

        private void UpdateView()
        {
            _view.SetCount(_model.Count);
        }

        private void OnDestroy()
        {
            _view.OnResetButtonClicked -= ResetCounter;
            _view.OnStopButtonClicked -= StopCounter;
        }
    }
}