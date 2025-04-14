using UnityEngine;

public class DamageTest : MonoBehaviour
{
    public float damage = 10;
    public PlayerWithoutObserver player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.TakeDamage(damage);
        }
    }
}