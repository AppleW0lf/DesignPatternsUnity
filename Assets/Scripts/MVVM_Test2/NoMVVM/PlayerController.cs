using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MVVM_Test2.NoMVVM
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private GameManager gameManager; // Ссылка на GameManager

        private void Start()
        {
            gameManager = FindFirstObjectByType<GameManager>(); // Находим GameManager при старте
            if (gameManager == null)
            {
                Debug.LogError("GameManager not found in the scene!");
            }
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Target>() != null)
            {
                Destroy(other.gameObject);
                if (gameManager != null)
                {
                    gameManager.CollectTarget(); // Вызываем метод увеличения счета в GameManager
                }
            }
        }
    }
}