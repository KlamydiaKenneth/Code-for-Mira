using UnityEngine;
using System.Collections;

/*
 * This modified version of the player controller script adds a Mario-like jump and a double-jump feature (this one is commented out)
 */

public class DoubleJump : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;


    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    //flag to remember if the player has already double-jumped or not during each jump
    bool hasDoubleJumped = false;


    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        /* --------------DOUBLE-JUMP code------------------
        //If the player is touching the ground then reset the hasDoubleJumped variable, so that next time the player jumps it can double jump again
        if (grounded)
        {
            hasDoubleJumped = false;
        }
        
        // IF:
        // -the player has pressed down the jump button
        // AND
        // the player is in the air (not grounded, remember "!" works is the way you write "not")
        // AND
        // the player has NOT double-jumped
        if (Input.GetButtonDown("Jump") && !grounded && !hasDoubleJumped)
        {
            //THEN jump again (set the jump variable true), and save that the player has double-jumped (hasDoubleJumped=true)
            jump = true;
            hasDoubleJumped = true;
        }
        -------------END DOUBLE-JUMP CODE------------------------------*/

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        // --------------Mario-ish jump code------------------
        //if the player is holding the jump button AND is not on the ground
        if (Input.GetButton("Jump") && !grounded)
        {
            //the gravity effect for the gameObject is reduced to 50%
            //gravityScale is a value from 0 to 1, where 0 means no gravity (0%), while 1 is full gravity (100%)
            rb2d.gravityScale = 0.5f;
        }

        //if the player releases the jump button (the button goes "up") set back the gravity to the normal (100%)
        if (Input.GetButtonUp("Jump"))
        {
            rb2d.gravityScale = 1f;
        }
        // -------------- END Mario-ish jump code------------------
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);
        
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}