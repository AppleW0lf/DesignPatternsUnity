using System;
using UnityEngine;

public class PlayerWithObserver : MonoBehaviour
{
    public float health = 100f;

    // Объявляем событие (Action)
    public event Action<float> OnHealthChanged;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0) health = 0;

        // Вызываем событие, если кто-то на него подписан
        OnHealthChanged?.Invoke(health);
    }
}