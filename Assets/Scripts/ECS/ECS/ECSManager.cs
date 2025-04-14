using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.ECS.ECS
{
    public class ECSManager : MonoBehaviour
    {
        public int numberOfEntities = 1000;
        public GameObject squarePrefab;

        private Dictionary<int, PositionComponent> _positions = new Dictionary<int, PositionComponent>();
        private Dictionary<int, VelocityComponent> _velocities = new Dictionary<int, VelocityComponent>();
        private List<GameObject> _entityGameObjects = new List<GameObject>(); // Для связи с Unity

        private MovementSystem _movementSystem;
        private int _nextEntityId = 0;

        private void Start()
        {
            _movementSystem = new MovementSystem(_positions, _velocities);

            // Создание сущностей
            for (int i = 0; i < numberOfEntities; i++)
            {
                CreateEntity();
            }
        }

        private void Update()
        {
            _movementSystem.Update(Time.deltaTime);

            // Обновление позиций GameObject'ов (связь ECS с Unity)
            foreach (var kvp in _positions)
            {
                int entityId = kvp.Key;
                Vector2 position = kvp.Value.position;
                _entityGameObjects[entityId].transform.position = position;
            }
        }

        private void CreateEntity()
        {
            int entityId = _nextEntityId++;

            // Создаем компоненты
            PositionComponent position = new PositionComponent
            {
                position = Random.insideUnitCircle * 5 // Начальная позиция
            };
            VelocityComponent velocity = new VelocityComponent
            {
                velocity = Random.insideUnitCircle.normalized,
                speed = 5f
            };

            // Добавляем компоненты в словари
            _positions.Add(entityId, position);
            _velocities.Add(entityId, velocity);
            _movementSystem.Register(entityId);

            // Создаем GameObject для представления сущности (связь с Unity)
            GameObject go = Instantiate(squarePrefab);
            go.transform.position = position.position;
            _entityGameObjects.Add(go);

            // Даем GameObject имя, чтобы было легче отслеживать
            go.name = "Entity_" + entityId;
        }
    }
}