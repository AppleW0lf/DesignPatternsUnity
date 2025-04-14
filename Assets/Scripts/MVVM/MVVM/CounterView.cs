using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MVVM.MVVM
{
    public class CounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private Button _incrementButton;
        [SerializeField] private CounterViewModel _viewModel;

        private void OnEnable()
        {
            _viewModel.OnCountUpdated += UpdateUI;
            _incrementButton.onClick.AddListener(_viewModel.Increment);
        }

        private void OnDisable()
        {
            _viewModel.OnCountUpdated -= UpdateUI;
            _incrementButton.onClick.RemoveListener(_viewModel.Increment);
        }

        private void UpdateUI(int count) => _countText.text = count.ToString();
    }
}