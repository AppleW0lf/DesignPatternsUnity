using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public float speed;

    public virtual void Move()
    {
        // Базовая логика движения
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Initialize(float health, float speed)
    {
        this.health = health;
        this.speed = speed;
    }
}