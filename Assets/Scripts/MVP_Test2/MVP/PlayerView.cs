using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MVP_Test2.MVP
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Slider _healthBar;
        [SerializeField] private Collider2D _collider;

        // Событие для атаки
        public event Action OnAttack;

        private void OnMouseDown()
        {
            OnAttack?.Invoke(); // Вызываем при клике
        }

        public void UpdateHealth(int health) => _healthBar.value = health;
    }
}