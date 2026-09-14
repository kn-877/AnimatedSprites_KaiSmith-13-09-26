using UnityEngine;

public class PumpkinMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(
            horizontalInput,
            verticalInput
        ).normalized;

        bool isMoving = moveInput != Vector2.zero;
        animator.SetBool("IsMoving", isMoving);

        FlipPumpkin();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(
            rb.position + moveInput * moveSpeed * Time.fixedDeltaTime
        );
    }

    private void FlipPumpkin()
    {
        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}