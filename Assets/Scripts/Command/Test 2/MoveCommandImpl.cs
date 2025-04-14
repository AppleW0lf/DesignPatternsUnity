using UnityEngine;

namespace Assets.Scripts.Command
{
    public class MoveCommandImpl : MoveCommand
    {
        public MoveCommandImpl(Transform transform, Vector3 direction, float stepDistance = 1) : base(transform, direction, stepDistance)
        {
        }

        public override void Execute()
        {
            transform.position += direction * stepDistance;
        }

        public override void Undo()
        {
            transform.position -= direction * stepDistance;
        }
    }
}
