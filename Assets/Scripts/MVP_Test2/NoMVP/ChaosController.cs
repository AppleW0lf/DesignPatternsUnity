using Assets.Scripts.MVP_Test2.NoMVP;
using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChaosController : MonoBehaviour
{
    // Player
    [SerializeField] private Slider _playerHealthBar;

    [SerializeField] private Button _pauseButton;

    private int _playerHealth = 100;

    // Enemies
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private ParticleSystem _enemyDeathEffect;

    // UI
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;

    private void Start()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        SpawnEnemies();
        stopwatch.Stop();
        UnityEngine.Debug.Log($"No MVP Time: {stopwatch.ElapsedMilliseconds} ms");
        //StartCoroutine(SpawnEnemies());
        _pauseButton.onClick.AddListener(() => Time.timeScale = 0);
    }

    public void PlayerTakeDamage()
    {
        _playerHealth -= 10;
        _playerHealthBar.value = _playerHealth;

        if (_playerHealth <= 0)
        {
            // Handle death logic mixed with UI
            _scoreText.color = Color.red;
        }
    }

    /*private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            var enemy = Instantiate(_enemyPrefab);
            enemy.GetComponent<EnemyChaos>().controller = this;
            yield return new WaitForSeconds(2);
        }
    }*/

    private void SpawnEnemies()
    {
        for (int i = 0; i < 100; i++)
        {
            var enemy = Instantiate(_enemyPrefab);
            enemy.GetComponent<EnemyChaos>().controller = this;
            //EnemyKilled(enemy);
        }
    }

    public void EnemyKilled(GameObject enemy)
    {
        _score += 100;
        _scoreText.text = $"Score: {_score}";
        Instantiate(_enemyDeathEffect, transform.position, Quaternion.identity);
        GameObject.Destroy(enemy);
    }
}