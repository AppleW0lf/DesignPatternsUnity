using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MVVM_Test2.MVVM
{
    public class GameViewModel
    {
        public GameModel GameModel { get; }
        public PlayerViewModel PlayerViewModel { get; }

        public event Action<int> ScoreChanged;

        public List<TargetViewModel> TargetViewModels { get; } = new List<TargetViewModel>(); // Список ViewModel целей

        public GameViewModel(GameModel gameModel, PlayerViewModel playerViewModel)
        {
            GameModel = gameModel;
            PlayerViewModel = playerViewModel;
            GameModel.ScoreChanged += OnScoreChanged;

            // Инициализация ViewModel для целей
            foreach (var targetModel in gameModel.Targets)
            {
                TargetViewModels.Add(new TargetViewModel(targetModel));
            }
        }

        private void OnScoreChanged(int newScore)
        {
            ScoreChanged?.Invoke(newScore);
        }

        public void CollectTarget()
        {
            GameModel.CollectTarget();
        }
    }
}