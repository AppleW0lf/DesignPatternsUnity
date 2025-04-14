using UnityEngine;
using UnityEngine.UI;

public class EnemyMonolithic : MonoBehaviour
{
    public int health = 100;
    public Slider healthBar;

    private void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.value = health;
    }
}