using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerControl2 : MonoBehaviour
{
    //Makes the movement and jump Variable Editable in the Inspecter if set to public
    //Create a Variable for Movement and Jump
    public float moveSpeed;
    public float jumpSpeed;

    //Create Player Health Variable 
    public float playerHeart = 3;

    //A Boolean to keep track if we are touching the Ground
    bool grounded;

    //Creates a SpriteRenderer Variable
    SpriteRenderer spriteRenderer;

    //Creates a Rigidbody Variable 
    Rigidbody2D playerBody2D;

    //Creates a Animator Variable 
    Animator animator;

    //Create an END Event for the UI Game Over
    public UnityEvent endEvent;

    void Start()
    {
        //makes a Connection to the Rigidbody Compodent of the Player Sprite
        playerBody2D = GetComponent<Rigidbody2D>();

        //Sets a Boolean(True/False) to use to make sure we can not fly
        grounded = false;

        //makes a Connection to the spriteRender Compodent
        spriteRenderer = GetComponent<SpriteRenderer>();

        //makes a Connection to the Animator Compodent
        animator = gameObject.GetComponent<Animator>();
    }

    //*********************************//
    // Update is called once per frame //
    //********************************//
    void Update()
    {
        if (playerHeart > 0)
        {
            // Gets a -1,0,1 depending on if the Left(-1) or Right(1) is pressed
            float h = Input.GetAxisRaw("Horizontal");

            //Player Funtion
            playerAnimation(h, grounded);

            //velocity adds movemnt to a specified vector2(x,y)
            playerBody2D.velocity = new Vector2(h * moveSpeed, playerBody2D.velocity.y);

            //Gets the a True when the Space bar is Pressed
            //Checks weather the Player Object is on the ground
            if (Input.GetButtonDown("Jump") && grounded == true)
            {
                playerBody2D.velocity = new Vector2(playerBody2D.velocity.x, jumpSpeed);
                grounded = false;
                //Debug.Log("Jump");
                //Sets Grounded Boolean to false
            }
        }
        else
        {
            playerEnd();
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R");
                SceneManager.LoadScene("Unit 1.1.2");
            }
        }
        if (playerBody2D.position.y < -20)
        {
            playerEnd();
        }
    }

    private void playerEnd()
    {
        spriteRenderer.enabled = false;
        endEvent.Invoke();

    }

    //*******************//
    // Animation Funtions //
    //*******************//
    //Controls the Animations of the Player Sprite
    private void playerAnimation(float h, bool ground)
    {
        if (h < 0)
        {
            //To Triggar the animation to Flip Left
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
        }
        if (h>0)
        {
            //To Triggar the animation to Flip Right
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
        }
        if (h == 0)
        {
            animator.SetBool("isRunning", false);
        }
        if (ground == false)
        {
            //To Triggar the animation for Jumping
            animator.SetBool("isJumping", true);
        }
    }

    //*******************//
    // Collions Funtions //
    //*******************//
    //Called when an incoming collider makes contact with this object's collider.
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks to make sure that the tag of the object is "Floor"
        //Debug.Log("collision Tag: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Floor")
        {
            //To stop the animation for Jumping
            animator.SetBool("isJumping", false);
            grounded = true;

            //this Changes the parents so when the Character Sprite
            //is on a Moving Platform the player can ride the platform
            this.transform.parent = collision.transform;
        }
        if (collision.gameObject.tag == "Damage")
        {
            playerHeart = playerHeart - 1;
            Debug.Log("Damage: " + playerHeart);

        }
        if (collision.gameObject.tag == "NextLevel")
        {
            Debug.Log("Next Level");
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            //this Changes the parents so when the Character Sprite
            //jumps when on a Moving Platform the player 
            //is not effected by the platforms movement
            this.transform.parent = null;
        }
    }
        
}