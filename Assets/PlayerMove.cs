using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRederer;
    public Animator animator;
    public bool betterJump = false;
    public float falMultiplayer = 0.5f;
    public float lowJumpMultiplayer = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            spriteRederer.flipX = false;
            animator.SetBool("run", true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
            spriteRederer.flipX = true;
            animator.SetBool("run", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("run", false);
        }

        if ((Input.GetKey(KeyCode.Space) && CheckGround.isGrounded  || Input.GetKey(KeyCode.UpArrow)) && CheckGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpSpeed);
        }

        if (!CheckGround.isGrounded)
        {
            animator.SetBool("jump", true);
            animator.SetBool("run", false);
        }

        if (CheckGround.isGrounded)
        {
            animator.SetBool("jump", false);
        }

        if (betterJump)
        {
            if(rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (falMultiplayer) * Time.deltaTime;
            }
            
            if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer) * Time.deltaTime;
            }
        }
    }
}
