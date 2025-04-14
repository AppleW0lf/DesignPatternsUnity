using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MVP.WithMVP
{
    public class CounterView : MonoBehaviour
    {
        public TextMeshProUGUI CounterText;
        public TextMeshProUGUI MessageText;
        public Button ResetButton;
        public Button StopButton; // Кнопка "Стоп"

        public event Action OnResetButtonClicked;

        public event Action OnStopButtonClicked; // Событие для кнопки "Стоп"

        private void Start()
        {
            ResetButton.onClick.AddListener(() => OnResetButtonClicked?.Invoke());
            StopButton.onClick.AddListener(() => OnStopButtonClicked?.Invoke()); // Подписываемся на кнопку "Стоп"
            MessageText.gameObject.SetActive(false);
        }

        public void SetCount(int count)
        {
            CounterText.text = "Count: " + count;
        }

        public void ShowResetMessage()
        {
            MessageText.text = "Counter was reset!";
            MessageText.gameObject.SetActive(true);
            Invoke("HideResetMessage", 2f);
        }

        private void HideResetMessage()
        {
            MessageText.gameObject.SetActive(false);
        }

        public void DisableButtons()
        {
            ResetButton.interactable = false;
            StopButton.interactable = false;
        }

        private void OnDestroy()
        {
            ResetButton.onClick.RemoveAllListeners();
            StopButton.onClick.RemoveAllListeners(); // Важно отписаться!
        }
    }
}