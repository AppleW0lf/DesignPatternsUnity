using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public float respawnTime = 2f;
    private float _nextRespawnTime;
    public float speed = 10f;

    private void OnEnable()
    {
        _nextRespawnTime = float.PositiveInfinity;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x > 10f)
        {
            ReturnToPool();
        }

        if (Time.time > _nextRespawnTime && _nextRespawnTime != float.PositiveInfinity)
        {
            ReturnToPool();
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void SetLifeTime(float lifeTime)
    {
        _nextRespawnTime = Time.time + lifeTime;
    }

    private void ReturnToPool()
    {
        BulletPool.Instance.ReturnToPool(this);
    }
}