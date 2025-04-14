namespace Assets.Scripts.MVVM_Test2.MVVM
{
    public class PlayerModel
    {
        public float MoveSpeed { get; set; }
        public float PositionX { get; set; }

        public PlayerModel(float moveSpeed)
        {
            MoveSpeed = moveSpeed;
            PositionX = 0; // начальная позиция
        }
    }
}