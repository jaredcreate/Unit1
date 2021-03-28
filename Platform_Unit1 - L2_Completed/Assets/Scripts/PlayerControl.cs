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


    //A Boolean to keep track if we are touching the Ground
    bool grounded;

    //Creates a Rigidbody
    Rigidbody2D character2D;

    //Creates a Animator Variable 


    //Creates a SpriteRenderer Variable


    //Create an END Event for the UI Game Over


    void Start()
    {
        //makes a Connection to the Rigidbody Component of the Player Sprite
        character2D = GetComponent<Rigidbody2D>();

        //Sets a Boolean(True/False) to use to make sure we can not fly
        grounded = false;

        //makes a Connection to the Animator Component


        //makes a Connection to the spriteRender Component

    }

    void Update()
    {
        //If Player Lives
        if (true)
        {
            // Gets a -1,0,1 depending on if the Left(-1) or Right(1) is pressed
            // Debug.Log(Input.GetAxisRaw("Horizontal"));
            float h = Input.GetAxisRaw("Horizontal");

            //velocity adds movement to a specified vector2(x,y)
            character2D.velocity = new Vector2(h * moveSpeed, character2D.velocity.y);

            //Function call for Animation


            //Becomes True when the Space bar is Pressed AND is Touching the Ground
            if (Input.GetButtonDown("Jump") && grounded == true)
            {
                //Calculate Movement for Player Object
                character2D.velocity = new Vector2(character2D.velocity.x, jumpSpeed);

                //Sets Grounded Boolean to false
                grounded = false;

                //Sets Jumping Boolean to false

            }
        }
        else
        {
            //End Player

            //Reset 
            if (true)
            {

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

            //To Trigger the Jumping animation Off


            //this Changes the parents so when the Character Sprite
            //is on a Moving Platform the player can ride the platform

        }
        //Add Damage 
        if (true)
        {
            //Player Health Damage
            //Debug.Log("Damage: " + playerHealth);



        }
        //Move to Next Level
        if (true)
        {

        }
    }
    //*******************//
    // Animation Functions //
    //*******************//
    //Controls the Animations of the Player Sprite
    private void playerAnimation()
    {
        if (true)
        {
            //To Trigger the Running animation Off

            //Flip on X Right

        }
        if (true)
        {
            //To Trigger the Running animation On

            //Flip on X Left

        }
        if (true)
        {
            //To Trigger the Running animation Off

        }
        if (true)
        {
            //To Trigger the Jumping animation On

        }
    }
    //*******************//
    // End Game Function //
    //*******************//
    private void playerEnd()
    {
        //Turn off the Player's Object Renderer

    }
    //A GETTER Function for the PlayerHealth Variable 
    public int gethearts()
    {
        return 0;
    }
}