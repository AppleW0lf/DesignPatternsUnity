using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVP_Test2.MVP
{
    public class GameManagerPresenter
    {
        private GameModel _model;
        private GameUIView _view;

        public GameManagerPresenter(GameModel model, GameUIView view)
        {
            _model = model;
            _view = view;
            view.SetPauseButtonCallback(PauseGame);
        }

        private void PauseGame() => Time.timeScale = 0;
    }
}