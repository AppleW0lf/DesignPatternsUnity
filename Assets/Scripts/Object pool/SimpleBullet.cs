using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    public float speed = 10f;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x > 10f)
            Destroy(gameObject);
    }
}