using Assets.Scripts.ECS.LeoECS.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Assets.Scripts.ECS.LeoECS
{
    public class MovementSystem : IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<Position> _positionPool;
        private EcsPool<Velocity> _velocityPool;

        public void Run(IEcsSystems systems)
        {
            // Получаем мир
            var world = systems.GetWorld();

            // Получаем фильтр по компонентам (Position и Velocity)
            _filter = world.Filter<Position>().Inc<Velocity>().End();
            _positionPool = world.GetPool<Position>();
            _velocityPool = world.GetPool<Velocity>();

            // Итерируемся по сущностям, удовлетворяющим фильтру
            foreach (int entity in _filter)
            {
                // Получаем компоненты для текущей сущности
                ref var position = ref _positionPool.Get(entity);
                ref var velocity = ref _velocityPool.Get(entity);

                // Обновляем позицию
                position.Value += velocity.Value * velocity.Speed * Time.deltaTime;

                // Логика отскока (простая)
                if (position.Value.x < -10 || position.Value.x > 10)
                {
                    velocity.Value.x *= -1;
                }
                if (position.Value.y < -5 || position.Value.y > 5)
                {
                    velocity.Value.y *= -1;
                }
            }
        }
    }
}