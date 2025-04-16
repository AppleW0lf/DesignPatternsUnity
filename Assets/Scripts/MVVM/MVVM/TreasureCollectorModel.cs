using System;
using UnityEngine;

namespace Assets.Scripts.MVVM.MVVM
{
    public class TreasureCollectorModel
    {
        private int _score = 0;

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnScoreChanged?.Invoke(_score);
            }
        }

        public event Action<int> OnScoreChanged;

        public void IncrementScore()
        {
            Score++;
        }
    }
}