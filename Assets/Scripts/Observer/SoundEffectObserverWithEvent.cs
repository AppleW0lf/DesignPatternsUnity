using UnityEngine;

public class SoundEffectObserverWithEvent : MonoBehaviour
{
    public AudioSource hurtSound;

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
        hurtSound.Play();
    }
}