using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    float movement;
    public float playerSpeed = 5;
    public float jumpForce = 1;

    public Animator animator;

    public Transform groundDetector;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public int extraJumps;
    private int extraJumpsLeft;

    private bool isRunning = false;
    private bool isFasingRight = true;
    private bool canJump = true;
    private bool isGrounded; 
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        extraJumpsLeft = extraJumps;      
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundDetector.position, groundCheckRadius, whatIsGround);

        if (isGrounded && rb.velocity.y<=0)
        {
            canJump = true;
            extraJumpsLeft = extraJumps;
            animator.SetFloat("jump", 0);
            animator.SetFloat("land", 1);
        }


        movement = Input.GetAxisRaw("Horizontal");
        
        if(isFasingRight && movement < 0)
        {
            Flip();
        }
        else if(!isFasingRight && movement> 0)
        {
            Flip();
        }


        rb.velocity = new Vector2(movement * playerSpeed, rb.velocity.y);

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (isRunning)
            {
                isRunning= false;
                //Debug.Log(isRunning);
            }
            else
            {
                isRunning = true;
            }
        }

        
        if (movement!=0 )
        {
            if(isRunning)
            {
              animator.SetFloat("run", 1);
            }
            else
            {
            animator.SetFloat("move", 1);

            }

        }
        else
        {
            if (isRunning)
            {
                animator.SetFloat("run", 0);
            }
            else
            {
                animator.SetFloat("move", 0);

            }
        }


        if (Input.GetButtonDown("Jump"))
        {

            if (canJump||extraJumpsLeft>=0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                Vector2 jumpForcetoAdd = new Vector2(0,jumpForce);
                rb.AddForce(jumpForcetoAdd, ForceMode2D.Impulse);
                animator.SetFloat("jump", 1);
                canJump= false;
                extraJumpsLeft--;
            }
        }
    }

    void Flip()
    {
        isFasingRight =!isFasingRight;
        transform.Rotate(0.0f, 180.0f, 0);
    }


}
