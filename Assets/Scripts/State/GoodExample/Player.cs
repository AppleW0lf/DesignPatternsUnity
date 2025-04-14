using Assets.Scripts.State.GoodExample;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public interface IPlayerState
{
    void Enter(Player player);

    void Update(Player player);

    void Exit(Player player);
}

public class Player : MonoBehaviour
{
    public IPlayerState currentState { get; private set; }
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Начальное состояние
        TransitionTo(new IdleState());
    }

    private void Update()
    {
        currentState?.Update(this);
    }

    public void TransitionTo(IPlayerState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    public Rigidbody2D GetRigidbody() => rb;

    public SpriteRenderer GetSpriteRenderer() => spriteRenderer;
}