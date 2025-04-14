using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MVP_Test2.MVP
{
    public class GameUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _pauseButton;

        public void SetPauseButtonCallback(Action callback)
        {
            _pauseButton.onClick.RemoveAllListeners();
            _pauseButton.onClick.AddListener(() => callback?.Invoke());
        }

        public void UpdateScore(int score) => _scoreText.text = $"Score: {score}";
    }
}