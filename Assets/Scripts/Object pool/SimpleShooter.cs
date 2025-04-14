using UnityEngine;

public class SimpleShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireInterval = 0.1f;
    public float bulletSpeed = 10f;
    private float nextFireTime;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireInterval;
            GameObject bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation);
            SimpleBullet bullet = bulletObj.GetComponent<SimpleBullet>();
            if (bullet != null)
            {
                bullet.SetSpeed(bulletSpeed);
            }
        }
    }
}