using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWithoutObserver : MonoBehaviour
{
    public float health = 100f;
    public UIHealthBar uiHealthBar;
    public AudioSource hurtSound;
    public ParticleSystem hurtEffect;

    private void Start()
    {
        // Поиск UIHealthBar
        uiHealthBar = FindObjectOfType<UIHealthBar>();
        if (uiHealthBar == null)
        {
            Debug.LogError("UIHealthBar not found in the scene");
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0) health = 0;

        // Прямой вызов методов других классов
        uiHealthBar.UpdateHealthBar(health);
        hurtSound.Play();
        hurtEffect.Play();
    }
}