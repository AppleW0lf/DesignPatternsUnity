using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; }
    public GameObject bulletPrefab;
    public int initialPoolSize = 10;
    public int maxPoolSize = 20;
    private Queue<PooledObject> pool;
    private Transform poolParent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        pool = new Queue<PooledObject>();
        poolParent = new GameObject("BulletPool").transform;
        poolParent.parent = transform;

        InitializePool(initialPoolSize);
    }

    private void InitializePool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(bulletPrefab, poolParent);
            PooledObject pooledBullet = obj.GetComponent<PooledObject>();
            if (pooledBullet == null)
            {
                pooledBullet = obj.AddComponent<PooledObject>();
            }
            pooledBullet.Deactivate();
            pool.Enqueue(pooledBullet);
        }
    }

    public PooledObject GetPooledBullet()
    {
        if (pool.Count > 0)
        {
            PooledObject bullet = pool.Dequeue();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            // Если пул пустой и не достиг максимального размера
            if (pool.Count + transform.childCount < maxPoolSize)
            {
                GameObject newBullet = Instantiate(bulletPrefab, poolParent);
                PooledObject pooledBullet = newBullet.GetComponent<PooledObject>();
                if (pooledBullet == null)
                {
                    pooledBullet = newBullet.AddComponent<PooledObject>();
                }
                pooledBullet.transform.position = transform.position;
                pooledBullet.transform.rotation = Quaternion.identity;
                pooledBullet.gameObject.SetActive(true);
                return pooledBullet;
            }
            else
            {
                Debug.LogWarning("Bullet pool is at max size.  Consider increasing maxPoolSize.");
                return null;
            }
        }
    }

    public void ReturnToPool(PooledObject bullet)
    {
        if (bullet != null && bullet.gameObject.activeSelf)
        {
            bullet.Deactivate();
            pool.Enqueue(bullet);
        }
    }
}