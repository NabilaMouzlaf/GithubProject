using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public float speed;
    public float jumpForce;
    public LayerMask jumpableGround;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            anim.SetTrigger("isJumping");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (dirX > 0)
        {
            sprite.flipX = false;
            anim.SetBool("isRunning", true);
        }
        else if (dirX < 0)
        {
            sprite.flipX = true;
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetTrigger("attack1");
        }
        else if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            anim.SetTrigger("attack2");
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("attack3");
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
