using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ECS.ECS
{
    public class MovementSystem
    {
        private List<int> _entities;  // ID сущностей, которые нужно двигать
        private Dictionary<int, PositionComponent> _positions;
        private Dictionary<int, VelocityComponent> _velocities;

        public MovementSystem(Dictionary<int, PositionComponent> positions, Dictionary<int, VelocityComponent> velocities)
        {
            _entities = new List<int>();
            _positions = positions;
            _velocities = velocities;
        }

        public void Register(int entityId)
        {
            _entities.Add(entityId);
        }

        public void Update(float deltaTime)
        {
            foreach (int entityId in _entities)
            {
                if (_positions.ContainsKey(entityId) && _velocities.ContainsKey(entityId))
                {
                    PositionComponent position = _positions[entityId];
                    VelocityComponent velocity = _velocities[entityId];

                    position.position += velocity.velocity * velocity.speed * deltaTime;

                    // Простая логика отскока (очень упрощенная)
                    if (position.position.x < -10 || position.position.x > 10)
                    {
                        velocity.velocity.x *= -1;
                    }
                    if (position.position.y < -5 || position.position.y > 5)
                    {
                        velocity.velocity.y *= -1;
                    }

                    _positions[entityId] = position; // Обновляем позицию
                    _velocities[entityId] = velocity; // Обновляем скорость (если нужно)
                }
            }
        }
    }
}