using UnityEngine;

public class HurtEffectObserverWithEvent : MonoBehaviour
{
    public ParticleSystem hurtEffect;

    public void Initialize(PlayerWithObserver player)
    {
        player.OnHealthChanged += OnHealthChanged; // Подписка на событие
    }

    private void OnDestroy()
    {
        FindFirstObjectByType<PlayerWithObserver>().OnHealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        hurtEffect.Play();
    }
}