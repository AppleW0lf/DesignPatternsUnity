using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVP_Test2.MVP
{
    public class EnemyPresenter
    {
        private EnemyModel _model;
        private EnemyView _view;
        private GameModel _gameModel;

        public EnemyPresenter(EnemyModel model, EnemyView view, GameModel gameModel)
        {
            _model = model;
            _view = view;
            _gameModel = gameModel;
            view.OnAttack += HandleAttack;
            _model.OnDeath += (model) =>
            {
                _view.PlayDeathEffect();
                _gameModel.AddScore(100);
                GameObject.Destroy(_view.gameObject, 1f);
            };
        }

        public void HandleAttack() => _model.TakeDamage(15);
    }
}