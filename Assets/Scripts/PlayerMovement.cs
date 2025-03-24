using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveDirection;
    private SpriteRenderer spriteRenderer;

    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private Animator animator;

     public AnimationClip walkUpAnimation;
    public AnimationClip walkDownAnimation;
    public AnimationClip walkLeftAnimation;
    public AnimationClip walkRightAnimation;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();
        // Change sprite based on movement direction
        UpdateSprite();

        // Calculate potential new position
        Vector3 nextPosition = transform.position + (Vector3)moveDirection * moveSpeed * Time.deltaTime;

        if (!Physics2D.Raycast(transform.position, moveDirection, 0.5f, LayerMask.GetMask("Wall")))
        {
            transform.position = nextPosition;
        }
    }

    void UpdateSprite()
    {
        //Debug.Log((Vector3)moveDirection * moveSpeed * Time.deltaTime);
        
        if (moveDirection.y > 0)
        {
             animator.enabled = true;
           // Debug.Log((Vector3)moveDirection * moveSpeed * Time.deltaTime);
            if (moveDirection.magnitude <= 0)
            {
                animator.StopPlayback();
                spriteRenderer.sprite = spriteUp; 
            }
            else
                animator.Play(walkUpAnimation.name);
        }
        else if (moveDirection.y < 0)
        {
            animator.enabled = true;
            if (moveDirection.magnitude <= 0)
            {
                animator.StopPlayback();
                spriteRenderer.sprite = spriteDown; 
            }
            else
                animator.Play(walkDownAnimation.name);
        }
        else if (moveDirection.x > 0)
        {
            animator.enabled = true;
            if (moveDirection.magnitude <= 0)
            {
                animator.StopPlayback();
                spriteRenderer.sprite = spriteRight;
            }
            else
                animator.Play(walkRightAnimation.name);
        }
        else if (moveDirection.x < 0)
        {
            animator.enabled = true;
            if (moveDirection.magnitude <= 0)
            {
                animator.StopPlayback();
                spriteRenderer.sprite = spriteLeft;
            }
            else
                animator.Play(walkLeftAnimation.name);
        }
        else
            animator.enabled = false;

    }
}
