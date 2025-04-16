using Assets.Scripts.MVVM.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVVM.MVVM
{
    public class TreasureCollectorViewModel
    {
        private readonly TreasureCollectorModel _model;

        public event Action<string> OnScoreTextChanged;

        public TreasureCollectorViewModel(TreasureCollectorModel model)
        {
            _model = model;
            _model.OnScoreChanged += UpdateScoreText;
        }

        public void CollectCoin()
        {
            _model.IncrementScore();
        }

        private void UpdateScoreText(int newScore)
        {
            OnScoreTextChanged?.Invoke("Score: " + newScore);
        }

        public void Unsubscribe()
        {
            _model.OnScoreChanged -= UpdateScoreText;
        }
    }
}