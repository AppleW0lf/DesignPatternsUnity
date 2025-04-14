using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public float damage = 10f;
    public float lifeTime = 2f; // Время жизни атаки в секундах
    public string targetTag = "Player"; // Тэг цели для атаки

    protected float startTime;

    protected virtual void Start()
    {
        startTime = Time.time;
    }

    protected virtual void Update()
    {
        if (Time.time - startTime >= lifeTime)
        {
            Destroy(gameObject); // Уничтожаем объект после истечения времени жизни
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            // TODO: Нанесение урона.  В этом примере мы просто выводим сообщение в консоль
            Debug.Log($"Attack hit {other.name} for {damage} damage");
            Destroy(gameObject); // Уничтожаем объект после столкновения
        }
    }
}