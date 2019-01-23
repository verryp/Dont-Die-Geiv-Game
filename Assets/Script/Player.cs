using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    bool isDead;

    public float maxSpeed = 5;
    public float speed = 70f;
    public float jumpPower = 500f;
    private bool facingRight = true;
    private float moveX;

    public bool grounded;
    public bool canDoubleJump;

    public bool isPressMove = false;
    public bool isPressA = false;
    public bool isPressB = false;

    private Rigidbody2D rb2d;
    private Animator anim;

    public bool isGrounded;

	void Start ()
    {
        //PlayerRayCast ();
        grounded = true;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

      
    }
	
	void Update () {

        //if (isDead == true)
          //  grounded = true;
        
        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed",Mathf.Abs(rb2d.velocity.x));
        moveX = CrossPlatformInputManager.GetAxis("Horizontal");
        //moveX = Input.GetAxis("Horizontal");

        if (moveX < 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == false)
        {
            FlipPlayer();
        }

        if (grounded && isPressMove == false)
        {
            anim.Play("Player_Idle");
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded == true)
         {
             if(grounded)
             {
                 rb2d.AddForce(new Vector2(0,jumpPower),ForceMode2D.Force);
                 canDoubleJump = true;
             }
             else
             {
                 if(canDoubleJump)
                 {
                     canDoubleJump = false;
                     rb2d.velocity = new Vector2(rb2d.velocity.x,0);
                     rb2d.AddForce(Vector2.up * jumpPower/ 1.5f);
                 }
             }

             //isGrounded = false;
         }

       /*if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up *jumpPower);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower / 1.5f);
                }
            }

            //isGrounded = false;
        }*/
		/*if (GamePause.gamePaused == true)
			speed = 0f;*/
			
        
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h =CrossPlatformInputManager.GetAxis("Horizontal");
        //float h = Input.GetAxis("Horizontal");

        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        if (isPressMove)
        {
            //menggerakan player
            rb2d.AddForce((Vector2.right * speed) * h);
            //anim.Play("Player_Walk");
        }

        //rb2d.AddForce((Vector2.right * speed) * h);

        //membatasi kecepatan player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if(rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    /*void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage()
    {
        gameObject.GetComponent<Animation>().Play("Player_RedFlash");
    }*/
   

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
        }

        yield return 0;
    }


    void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "ground") {
			isGrounded = true;
		}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "dead" && !isDead)
        {
            rb2d.velocity = Vector2.zero;

            anim.SetBool("Die", true);
            rb2d.AddForce(new Vector2(0, 100));
            isDead = true;
            // levelManager.RespawnPlayer ();
        }
    }


        /*void PlayerRayCast(){
            RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);
            if (hit != null && hit.collider != null && hit.distance < 0.33f && hit.collider.tag == "Enemy") {
                GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);
                Destroy (hit.collider.gameObject);
            }

            if (hit != null && hit.collider != null && hit.distance < 0.33f && hit.collider.tag == "Enemy") {
                isGrounded = true;
            }
        }*/

        public void PressMove()
       {
        isPressMove = true;
     }

    public void PressB()
    {
        isPressB = true;
    }
    public void PressA()
    {
        isPressA = true;
    }
    public void UnPressMove()
    {
        isPressMove = false;
    }

    public void UnPressB()
    {
        isPressB = false;
    }
    public void UnPressA()
    {
        isPressA= false;
    }
}
