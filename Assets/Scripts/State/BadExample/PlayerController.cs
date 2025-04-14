using UnityEngine;

namespace Assets.Scripts.State.BadExample
{
    public class PlayerController : MonoBehaviour
    {
        public enum PlayerState
        {
            Idle,
            Running,
            Jumping,
            Crouching,
            Attacking,
            Defending,
            Sliding,
            Climbing,
            Swimming,
            Flying,
            Dashing
        }

        public PlayerState CurrentState { get; set; }
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            CurrentState = PlayerState.Idle;
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            HandleInput();
            UpdateState();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CurrentState = PlayerState.Jumping;
                rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                CurrentState = PlayerState.Crouching;
            }
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                CurrentState = PlayerState.Attacking;
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
                CurrentState = PlayerState.Defending;
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                CurrentState = PlayerState.Dashing;
            }
            else if (Input.GetAxis("Horizontal") != 0)
            {
                CurrentState = PlayerState.Running;
            }
            else if (Input.GetKey(KeyCode.C))
            {
                CurrentState = PlayerState.Sliding;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                CurrentState = PlayerState.Climbing;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                CurrentState = PlayerState.Swimming;
            }
            else if (Input.GetKey(KeyCode.F))
            {
                CurrentState = PlayerState.Flying;
            }
            else
            {
                CurrentState = PlayerState.Idle;
            }
        }

        public void UpdateState()
        {
            switch (CurrentState)
            {
                case PlayerState.Idle:
                    spriteRenderer.color = Color.blue; // Цвет для состояния Idle
                    break;

                case PlayerState.Running:
                    spriteRenderer.color = Color.green; // Цвет для состояния Running
                    float moveDirection = Input.GetAxis("Horizontal");
                    transform.Translate(Vector2.right * moveDirection * Time.deltaTime * 5f);
                    break;

                case PlayerState.Jumping:
                    spriteRenderer.color = Color.red; // Цвет для состояния Jumping
                    break;

                case PlayerState.Crouching:
                    spriteRenderer.color = Color.yellow; // Цвет для состояния Crouching
                    break;

                case PlayerState.Attacking:
                    spriteRenderer.color = Color.magenta; // Цвет для состояния Attacking
                    break;

                case PlayerState.Defending:
                    spriteRenderer.color = Color.cyan; // Цвет для состояния Defending
                    break;

                case PlayerState.Sliding:
                    spriteRenderer.color = Color.gray; // Цвет для состояния Sliding
                    break;

                case PlayerState.Climbing:
                    spriteRenderer.color = Color.white; // Цвет для состояния Climbing
                    break;

                case PlayerState.Swimming:
                    spriteRenderer.color = new Color(0, 0.5f, 1); // Цвет для состояния Swimming
                    break;

                case PlayerState.Flying:
                    spriteRenderer.color = new Color(1, 0.5f, 0); // Цвет для состояния Flying
                    break;

                case PlayerState.Dashing:
                    spriteRenderer.color = new Color(0.5f, 0, 1); // Цвет для состояния Dashing
                    break;
            }
        }
    }
}