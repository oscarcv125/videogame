using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomCowMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float walkDuration = 2f;
    public float idleDuration = 2f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private float timer;
    private bool isWalking = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartIdlePhase();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            isWalking = !isWalking;

            if (isWalking)
                StartWalkPhase();
            else
                StartIdlePhase();
        }

        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("IsMoving", isWalking);

        // Flip sprite if moving left
        if (movement.x < 0)
            spriteRenderer.flipX = true;
        else if (movement.x > 0)
            spriteRenderer.flipX = false;
    }

    void FixedUpdate()
    {
        if (isWalking)
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void StartWalkPhase()
    {
        movement = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)).normalized;
        timer = walkDuration;
    }

    void StartIdlePhase()
    {
        movement = Vector2.zero;
        timer = idleDuration;
    }
}