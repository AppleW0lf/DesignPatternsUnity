using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MVC
{
    public class EnemyView : MonoBehaviour
    {
        public Slider healthBar;

        public void SetHealth(int health)
        {
            healthBar.value = health;
        }
    }
}