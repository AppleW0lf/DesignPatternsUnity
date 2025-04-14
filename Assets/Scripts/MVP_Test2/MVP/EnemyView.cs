using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVP_Test2.MVP
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _deathEffect;
        [SerializeField] private Collider2D _collider;

        // Событие для атаки
        public event Action OnAttack;

        private void OnMouseDown()
        {
            OnAttack?.Invoke(); // Вызываем при клике
        }

        public void PlayDeathEffect() => _deathEffect.Play();
    }
}