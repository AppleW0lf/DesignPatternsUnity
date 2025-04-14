using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public BulletPool bulletPool;
    public float fireRate = 1f;
    private float nextFireTime;
    public float speed = 10f;

    private void Start()
    {
        bulletPool = FindFirstObjectByType<BulletPool>();
        if (bulletPool == null)
        {
            Debug.LogError("BulletPool is not found");
        }
    }

    private void Update()
    {
        if (bulletPool != null && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            PooledObject bullet = bulletPool.GetPooledBullet();
            if (bullet != null)
            {
                bullet.speed = speed;
            }
        }
    }
}