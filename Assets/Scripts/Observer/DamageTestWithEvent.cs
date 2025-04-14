using UnityEngine;

public class DamageTestWithEvent : MonoBehaviour
{
    public float damage = 10;
    public PlayerWithObserver player;
    public KeyCode damageKey = KeyCode.Space; // Кнопка по умолчанию - Пробел

    private void Start()
    {
        InitializeObservers();
        if (player == null)
        {
            Debug.LogError("DamageTestWithEvent: Player not found.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(damageKey))
        {
            ApplyDamage();
        }
    }

    private void ApplyDamage()
    {
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }

    private void InitializeObservers()
    {
        UIHealthBarObserverWithEvent healthBar = FindObjectOfType<UIHealthBarObserverWithEvent>();
        if (healthBar != null)
        {
            healthBar.Initialize(player);
        }
        SoundEffectObserverWithEvent soundObserver = FindObjectOfType<SoundEffectObserverWithEvent>();
        if (soundObserver != null)
        {
            soundObserver.Initialize(player);
        }
        HurtEffectObserverWithEvent effectObserver = FindObjectOfType<HurtEffectObserverWithEvent>();
        if (effectObserver != null)
        {
            effectObserver.Initialize(player);
        }
    }
}