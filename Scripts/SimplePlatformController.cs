using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformController : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = true;
    bool floating = false;

    // Physcis forces og groundcheck
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    [Range(0,1)] public float floatingForce = 0.5f;
    public Transform groundCheck;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;



	// Use this for initialization
	void Awake ()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        // Tjek for at se om du er grounded før du kan hoppe, ground er her bundet til din LayerMask kaldet Ground
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        // Når spilleren holder "Jump" nede og ikke er grounded, floater han
        if (Input.GetButton("Jump") && !grounded)
        {
            floating = true;
        }
	}

    void FixedUpdate()
    {
        // Her bestemmes der hvor hurtigt karakteren kan bevæge sig, samt en maks hastighed.
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));
        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        // her flippes din sprite til den retning du bevæger dig i.
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        // Her bestemmer du hvilken knap der er jump og hvordan dit jump fungere.
        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;

        }

        if (floating)
        {

            rb2d.AddForce(-Physics2D.gravity * floatingForce);
            floating = false;

        }
    }

    // her bestemmer du hvordan din flip af sprites fungere
    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    

}
