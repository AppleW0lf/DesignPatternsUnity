using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVC
{
    public class EnemyController : MonoBehaviour
    {
        private EnemyModel _model;
        public EnemyView view;
        public int maxHealth = 100;

        private void Awake()
        {
            _model = new EnemyModel(maxHealth);
        }

        private void Start()
        {
            view.healthBar.maxValue = maxHealth;
            _model.OnHealthChanged += view.SetHealth;
            view.SetHealth(_model.Health);
        }

        public void TakeDamage(int damage)
        {
            _model.TakeDamage(damage);
        }

        private void OnDestroy()
        {
            _model.OnHealthChanged -= view.SetHealth;
        }
    }
}