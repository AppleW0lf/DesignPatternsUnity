using UnityEngine;

public interface ICharacterMover
{
    void Move(Vector2 direction);
}

public class SimpleCharacterMover : ICharacterMover
{
    public float speed = 5f;
    private Rigidbody2D _rb;

    public SimpleCharacterMover(Rigidbody2D rb)
    {
        _rb = rb;
    }

    public void Move(Vector2 direction)
    {
        _rb.linearVelocity = direction * speed;
    }
}

// Сторонняя библиотека (симулируем)
public class AdvancedMovementLibrary
{
    public void MoveCharacter(Rigidbody2D rb, float xVelocity, float yVelocity)
    {
        // Более сложная логика перемещения
        rb.linearVelocity = new Vector2(xVelocity * 10f, yVelocity * 10f); // Увеличиваем скорость для примера
    }
}

public class CharacterControllerWithoutAdapter : MonoBehaviour
{
    public Rigidbody2D rb;
    private AdvancedMovementLibrary _advancedMover = new AdvancedMovementLibrary();

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Прямое использование сторонней библиотеки.
        _advancedMover.MoveCharacter(rb, horizontalInput, verticalInput);
    }
}