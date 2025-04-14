using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Command
{
    public abstract class MoveCommand
    {
        protected Transform transform;
        protected float stepDistance;
        protected Vector3 direction;

        public MoveCommand(Transform transform, Vector3 direction, float stepDistance = 1f)
        {
            this.transform = transform;
            this.direction = direction;
            this.stepDistance = stepDistance;
        }

        public abstract void Execute();

        public abstract void Undo();
    }
}