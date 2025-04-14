using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVP_Test2.MVP
{
    public class PlayerPresenter
    {
        private PlayerModel _model;
        private PlayerView _view;

        public PlayerPresenter(PlayerModel model, PlayerView view)
        {
            _model = model;
            _view = view;
            _model.OnHealthChanged += _view.UpdateHealth;
            _view.OnAttack += HandleDamage;
        }

        public void HandleDamage() => _model.TakeDamage(10);
    }
}