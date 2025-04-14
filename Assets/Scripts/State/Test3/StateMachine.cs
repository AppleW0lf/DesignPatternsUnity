using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.State.Test3
{
    public class StateMachine
    {
        private State StateCurrent { get; set; }
        private Dictionary<Type, State> _states = new();

        public void AddState(State state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SetState<T>() where T : State
        {
            var type = typeof(T);
            if (StateCurrent != null && StateCurrent.GetType() == type)
            {
                return;
            }
            if (_states.TryGetValue(type, out var newState))
            {
                StateCurrent?.Exit();
                StateCurrent = newState;
                StateCurrent.Enter();
            }
        }

        public void Update(Transform transform)
        {
            StateCurrent?.Update(transform);
        }
    }
}