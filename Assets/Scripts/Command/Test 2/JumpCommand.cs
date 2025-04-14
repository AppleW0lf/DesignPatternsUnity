using UnityEngine;

namespace Assets.Scripts.Command
{
    public class JumpCommand : MoveCommand
    {
        private float jumpHeight;

        public JumpCommand(Transform transform, float jumpHeight) : base(transform, Vector3.up, jumpHeight)
        {
            this.jumpHeight = jumpHeight;
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
