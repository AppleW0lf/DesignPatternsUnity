using Assets.Scripts.ECS.LeoECS.Components;
using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.ECS.LeoECS.Systems
{
    public class ViewSystem : IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<Position> _positionPool;
        private EcsPool<UnityObjectLink> _unityObjectLinkPool;

        public void Run(IEcsSystems systems) // <- IEcsSystems systems
        {
            // Получаем мир
            EcsWorld world = systems.GetWorld(); // <- Получаем мир из systems

            var filter = world.Filter<Position>().Inc<UnityObjectLink>().End();
            var positionPool = world.GetPool<Position>();
            var unityObjectLinkPool = world.GetPool<UnityObjectLink>();

            foreach (int entity in filter)
            {
                ref var position = ref positionPool.Get(entity);
                var unityObjectLink = unityObjectLinkPool.Get(entity);

                if (unityObjectLink.GameObject != null)
                {
                    unityObjectLink.GameObject.transform.position = position.Value;
                }
            }
        }
    }
}