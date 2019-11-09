using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    [Header("Dinesh Balakrishnan, Last Edited 01/11/2019")]
    // Shows the animation state of the player for documentation
    public AnimState heroAnimState;
    // Takes care of changing the animation clips appropriately
    public Animator heroAnimator;
    // Takes care of opposite direction animations
    public SpriteRenderer heroSpriteRenderer;
    // Accessing Rigidbody2D components
    public Rigidbody2D playerBody;
    // Physics (for adding kinematic energy)
    public float moveForce;
    public float jumpForce;
    public bool isGrounded;
    public GameObject Trap;
    public GameObject Arrow;
    public Transform groundTarget;
    public Vector2 maximumVelocity = new Vector2(20.0f, 30.0f);
    // Start is called before the first frame update
    void Start()
    {
        // Makes sure the game starts with player idle animation
        heroAnimState = AnimState.IDLE;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.Linecast(
            transform.position, groundTarget.position,
            1 << LayerMask.NameToLayer("Ground"));

        
        Movement();
    }

    void Movement()
    {
        // Idles the player
        if (Input.GetAxis("Horizontal") == 0)
        {
            // Shows the animation state
            heroAnimState = AnimState.IDLE;
            // Makes sure the correct animation is played
            heroAnimator.SetInteger("AnimState", (int)AnimState.IDLE);
        }
        // Gets Horizontal axis and move right
        if (Input.GetAxis("Horizontal") > 0)
        {
            heroSpriteRenderer.flipX = false;
            if (isGrounded)
            {
                // Shows the animation state
                heroAnimState = AnimState.WALK;
                // Makes sure the correct animation is played
                heroAnimator.SetInteger("AnimState", (int)AnimState.WALK);
                playerBody.AddForce(Vector2.right * moveForce);
            }       
        }
        // Gets Horizontal axis and move left
        if (Input.GetAxis("Horizontal") < 0)
        {
            heroSpriteRenderer.flipX = true;
            if (isGrounded)
            {
                // Shows the animation state
                heroAnimState = AnimState.WALK;
                // Makes sure the correct animation is played
                heroAnimator.SetInteger("AnimState", (int)AnimState.WALK);

                playerBody.AddForce(Vector2.left * moveForce);
            }
        }
        // Jump
        if ((Input.GetAxis("Jump") > 0) && (isGrounded))
        {
            playerBody.gravityScale = 2;
            // Shows the animation state
            heroAnimState = AnimState.JUMP;
            // Makes sure the correct animation is played
            heroAnimator.SetInteger("AnimState", (int)AnimState.JUMP);
            playerBody.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
        //Player normal attack
        if (Input.GetAxis("Attack") > 0)
        {
            // Shows the animation state
            heroAnimState = AnimState.ATTACK;
            // Makes sure the correct animation is played
            heroAnimator.SetInteger("AnimState", (int)AnimState.ATTACK);
        }
        playerBody.velocity = new Vector2(
           Mathf.Clamp(playerBody.velocity.x, -maximumVelocity.x, maximumVelocity.x),
           Mathf.Clamp(playerBody.velocity.y, -maximumVelocity.y, maximumVelocity.y)
           );
    }
    // When player hits traps, gets hit by enem/boss weapons this will play hurt animation
      void OnTriggeredEnter2D(Collider2D other)
      {
        if ((other.gameObject == Trap) || (other.gameObject == Arrow))
        {
            heroAnimState = AnimState.HURT;
            heroAnimator.SetInteger("AnimState", (int)AnimState.HURT);
            Destroy(this.gameObject);
        }
        
      }
}