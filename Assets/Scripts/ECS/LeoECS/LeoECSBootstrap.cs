using Assets.Scripts.ECS.LeoECS.Components;
using Assets.Scripts.ECS.LeoECS.Systems;
using Leopotam.EcsLite;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Assets.Scripts.ECS.LeoECS
{
    public class LeoECSBootstrap : MonoBehaviour
    {
        public int numberOfEntities = 100;
        public GameObject squarePrefab;

        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsPool<Position> _positionPool;
        private EcsPool<Velocity> _velocityPool;
        private EcsPool<UnityObjectLink> _unityObjectLinkPool;

        private void Start()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Debug.Log("Start() called");
            _world = new EcsWorld();
            Debug.Log("_world created");

            _systems = new EcsSystems(_world);
            Debug.Log("_systems created");

            _systems.Add(new MovementSystem());
            Debug.Log("MovementSystem added");

            _systems.Add(new ViewSystem());
            Debug.Log("ViewSystem added");

            _systems.Init(); // строка 54
            Debug.Log("_systems.Init() called");

            _positionPool = _world.GetPool<Position>();
            Debug.Log("_positionPool created");
            _velocityPool = _world.GetPool<Velocity>();
            _unityObjectLinkPool = _world.GetPool<UnityObjectLink>();

            // Создаем сущности
            for (int i = 0; i < numberOfEntities; i++)
            {
                // Создаем сущность
                int entity = _world.NewEntity();

                // Добавляем компоненты
                ref Position position = ref _positionPool.Add(entity);
                position.Value = new Vector2(Random.Range(-5f, 5f), Random.Range(-2.5f, 2.5f));

                ref Velocity velocity = ref _velocityPool.Add(entity);
                velocity.Value = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                velocity.Speed = 2f;

                // Связываем сущность с GameObject
                GameObject go = Instantiate(squarePrefab);
                go.transform.position = position.Value;

                ref UnityObjectLink unityObjectLink = ref _unityObjectLinkPool.Add(entity);
                unityObjectLink.GameObject = go;
            }
            stopwatch.Stop();
            UnityEngine.Debug.Log($"LeoECS Time: {stopwatch.ElapsedMilliseconds} ms");
        }

        private void Update()
        {
            // Запускаем системы каждый кадр
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}