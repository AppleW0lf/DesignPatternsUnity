using UnityEngine;

namespace Assets.Scripts.State.Test3
{
    public abstract class State
    {
        protected readonly StateMachine stateMachine;

        public State(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public virtual void Enter()
        { }

        public virtual void Update(Transform transform)
        { }

        public virtual void Exit()
        { }
    }
}