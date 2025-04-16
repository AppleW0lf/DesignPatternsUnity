using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVP_Test2.MVP
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private GameUIView _gameUIView;
        [SerializeField] private EnemyView _enemyPrefab;

        private PlayerModel _playerModel;
        private GameModel _gameModel;

        private void Start()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Инициализация моделей
            _playerModel = new PlayerModel();
            _gameModel = new GameModel();

            // Создание презентеров
            new PlayerPresenter(_playerModel, _playerView);
            new GameManagerPresenter(_gameModel, _gameUIView);

            // Спавн врагов
            //StartCoroutine(SpawnEnemies());
            SpawnEnemies();
            stopwatch.Stop();
            UnityEngine.Debug.Log($"MVP Pattern Time: {stopwatch.ElapsedMilliseconds} ms");
        }

        /*private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                var enemy = Instantiate(_enemyPrefab);
                var enemyModel = new EnemyModel();
                new EnemyPresenter(enemyModel, enemy, _gameModel);
                yield return new WaitForSeconds(10f);
            }
        }*/

        private void SpawnEnemies()
        {
            //float start = Time.realtimeSinceStartup;
            for (int i = 0; i < 100; i++)
            {
                var enemy = Instantiate(_enemyPrefab);
                var enemyModel = new EnemyModel();
                new EnemyPresenter(enemyModel, enemy, _gameModel).HandleAttack();
            }
            //Debug.Log($"MVP: {Time.realtimeSinceStartup - start}");
        }
    }
}