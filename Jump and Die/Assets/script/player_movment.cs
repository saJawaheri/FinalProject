using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movment : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 5f;
    [SerializeField]private float JumpForce = 10f;

    private enum MovmentState { idle, running, jumping, falling }
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
         dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        {
           rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovmentState state;

        if (dirX > 0f)
        {
            state = MovmentState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovmentState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovmentState.idle;

        }

        if(rb.velocity.y > .1f)
        {
            state = MovmentState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovmentState.falling;

        }
        anim.SetInteger("state", (int)state);
    }
 
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
