using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    //Makes the movement and jump Variable Editable in the Inspector if set to public
    //Create a Variable for Movement and Jump
    public float moveSpeed;
    public float jumpSpeed;

    //Create Player Health Variable 
    public int playerHealth = 3;

    //A Boolean to keep track if we are touching the Ground
    bool grounded;

    //Creates a Rigidbody
    Rigidbody2D character2D;

    //Creates a Animator Variable 
    Animator animator;

    //Creates a SpriteRenderer Variable
    SpriteRenderer spriteRenderer;

    //Create an END Event for the UI Game Over
    public UnityEvent endEvent;

    void Start()
    {
        //makes a Connection to the Rigidbody Component of the Player Sprite
        character2D = GetComponent<Rigidbody2D>();

        //Sets a Boolean(True/False) to use to make sure we can not fly
        grounded = false;

        //makes a Connection to the Animator Compodent
        animator = gameObject.GetComponent<Animator>();

        //makes a Connection to the spriteRender Compodent
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //If Player Lives
        if (playerHealth > 0)
        {
            // Gets a -1,0,1 depending on if the Left(-1) or Right(1) is pressed
            //Debug.Log(Input.GetAxisRaw("Horizontal"));
            float h = Input.GetAxisRaw("Horizontal");

            //velocity adds movement to a specified vector2(x,y)
            character2D.velocity = new Vector2(h * moveSpeed, character2D.velocity.y);

            //Fuction call for Animation
            playerAnimation(h, grounded);

            //Becomes True when the Space bar is Pressed AND is Touching the Ground
            if (Input.GetButtonDown("Jump") && grounded == true)
            {
                //Calculate Jump Movement for Player Object
                character2D.velocity = new Vector2(character2D.velocity.x, jumpSpeed);

                //Sets Grounded Boolean to false
                grounded = false;

                //Sets Jumping Boolean to false
                animator.SetBool("isJumping", false);
            }
        }
        else
        {
            //End Player
            playerEnd();
            //Reset 
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R");
                SceneManager.LoadScene("Lesson 3");
                //("Lesson 3") Needs to be the name of the Scene you want to Load
            }
        }
    }

    //*********************//
    // Collision Functions //
    //*********************//
    //Called when an incoming collider makes contact with this object's collider.
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks to make sure that the tag of the object is "Floor"
        if (collision.gameObject.tag == "Floor")
        {
            //Debug.Log("ON THE FLOOR");
            grounded = true;

            //To Triggar the Jumping animation Off
            animator.SetBool("isJumping", false);

            //this Changes the parents so when the Character Sprite
            //is on a Moving Platform the player can ride the platform
            this.transform.parent = collision.transform;
        }
        //Add Damage 
        if (collision.gameObject.tag == "Damage")
        {
            //Player Health Damage
            playerHealth = playerHealth - 1;
            Debug.Log("Damage: " + playerHealth);

        }
        //Move to Next Level
        if (collision.gameObject.tag == "NextLevel")
        {
            Debug.Log("Next Level");
        }
    }
    //Called when an collider leaves contact with this object's collider.
    void OnCollisionExit2D(Collision2D collision)
    {
        //Checks to make sure that the tag of the object is "Floor"
        if (collision.gameObject.tag == "Floor")
        {
            //Removes the Parent Platform from the Player 
            this.transform.SetParent(null);
        }
    }
    //*******************//
    // Animation Funtions //
    //*******************//
    //Controls the Animations of the Player Sprite
    private void playerAnimation(float h, bool ground)
    {
        if (h < 0)
        {
            //To Triggar the Running animation Off
            animator.SetBool("isRunning", true);
            //Flip X to Right
            spriteRenderer.flipX = true;
        }
        if (h > 0)
        {
            //To Triggar the Running animation On
            animator.SetBool("isRunning", true);
            //Flip X to Left
            spriteRenderer.flipX = false;
        }
        if (h == 0)
        {
            //To Triggar the Running animation Off
            animator.SetBool("isRunning", false);
        }
        if (ground == false)
        {
            //To Triggar the Jummping animation On
            animator.SetBool("isJumping", true);
        }
    }
    //*******************//
    // End Game Function //
    //*******************//
    private void playerEnd()
    {
        //Turn off the Player's Object Renderer
        spriteRenderer.enabled = false;
        endEvent.Invoke();
    }
    //A GETTER Function for the PlayerHealth Variable
    public int gethearts()
    {
        return playerHealth;
    }
}

