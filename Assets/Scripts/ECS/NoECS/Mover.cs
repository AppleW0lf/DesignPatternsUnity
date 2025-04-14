using UnityEngine;

namespace Assets.Scripts.ECS.NoECS
{
    public class Mover : MonoBehaviour
    {
        public float speed = 5f;
        private Vector2 _direction;

        private void Start()
        {
            _direction = Random.insideUnitCircle.normalized;
        }

        private void Update()
        {
            transform.Translate(_direction * speed * Time.deltaTime);

            // Простая логика отскока от границ экрана
            Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
            if (viewportPosition.x < 0 || viewportPosition.x > 1)
            {
                _direction.x *= -1;
            }
            if (viewportPosition.y < 0 || viewportPosition.y > 1)
            {
                _direction.y *= -1;
            }
        }
    }
}