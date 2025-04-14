using UnityEngine;

namespace Assets.Scripts.Command
{
    public class RotateCommand : MoveCommand
    {
        private float rotationAngle;
        private Quaternion previousRotation;

        public RotateCommand(Transform transform, float rotationAngle) : base(transform, Vector3.forward, rotationAngle)
        {
            this.rotationAngle = rotationAngle;
        }

        public override void Execute()
        {
            previousRotation = transform.rotation;
            transform.Rotate(Vector3.forward, stepDistance);
        }

        public override void Undo()
        {
            transform.rotation = previousRotation;
        }
    }
}