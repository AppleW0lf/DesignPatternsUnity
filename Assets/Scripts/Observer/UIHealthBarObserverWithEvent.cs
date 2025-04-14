using UnityEngine;
using UnityEngine.UI;

public class UIHealthBarObserverWithEvent : MonoBehaviour
{
    public Slider healthSlider;

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
        healthSlider.value = health;
    }
}