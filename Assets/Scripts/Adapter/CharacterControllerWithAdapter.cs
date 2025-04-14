using UnityEngine;

// Адаптер
public class AdvancedMovementAdapter : ICharacterMover
{
    private AdvancedMovementLibrary _advancedMover;
    private Rigidbody2D _rb;

    public AdvancedMovementAdapter(AdvancedMovementLibrary advancedMover, Rigidbody2D rb)
    {
        _advancedMover = advancedMover;
        _rb = rb;
    }

    public void Move(Vector2 direction)
    {
        _advancedMover.MoveCharacter(_rb, direction.x, direction.y);
    }
}

public class CharacterControllerWithAdapter : MonoBehaviour
{
    public Rigidbody2D rb;
    private ICharacterMover _characterMover;
    private Vector2 _moveDirection = Vector2.zero;

    private void Start()
    {
        _characterMover = new AdvancedMovementAdapter(new AdvancedMovementLibrary(), rb);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _moveDirection.x = horizontalInput;
        _moveDirection.y = verticalInput;

        _characterMover.Move(_moveDirection);
    }
}