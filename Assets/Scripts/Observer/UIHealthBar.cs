using Unity.VisualScripting;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    public UnityEngine.UI.Slider healthSlider;

    public void UpdateHealthBar(float health)
    {
        healthSlider.value = health;
    }
}