using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Command
{
    /*public class MoveDiagonalCommand : MoveCommand
    {
        private Vector3 directionDiagonal = new Vector3(1f, -1f, 0).normalized;

        public MoveDiagonalCommand(Transform transform, float stepDistance = 1) : base(transform, stepDistance)
        {
        }

        public override void Execute()
        {
            transform.position += directionDiagonal * stepDistance;
        }

        public override void Undo()
        {
            transform.position -= directionDiagonal * stepDistance;
        }
    }*/
}