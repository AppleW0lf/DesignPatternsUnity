using UnityEngine;

namespace Assets.Scripts.MVVM.MVVM
{
    public class CounterModel : MonoBehaviour
    {
        public event System.Action<int> OnCountChanged;

        private int _count;

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnCountChanged?.Invoke(_count);
            }
        }

        public void Increment() => Count++;
    }
}