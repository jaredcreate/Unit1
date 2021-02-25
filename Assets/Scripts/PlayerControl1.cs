using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl1 : MonoBehaviour
{
    //Makes the movement and jump Varible Editable in the Inspecter if set to public
    //Create a Varible for Movement and Jump
    public float moveSpeed;
    public float jumpSpeed;

    //A Boolean to keep track if we are touching the Ground
    bool grounded;


    //Creates a Rigidbody
    Rigidbody2D character2D;


    void Start()
    {
        //makes a Connection to the Rigidbody Compodent of the Player Sprite
        character2D = GetComponent<Rigidbody2D>();

        //Sets a Boolean(True/False) to use to make sure we can not fly
        grounded = false;

        
    }
    //*********************************//
    // Update is called once per frame //
    //********************************//
    void Update()
    {
        // Gets a -1,0,1 depending on if the Left(-1) or Right(1) is pressed
        float h = Input.GetAxisRaw("Horizontal");
        

        //velocity adds movemnt to a specified vector2(x,y)
        character2D.velocity = new Vector2(h * moveSpeed, character2D.velocity.y);
        
        Debug.Log("Velocity X:" + character2D.velocity.x);
        Debug.Log("Velocity Y:" + character2D.velocity.y);
        //character2D.velocity.y Get the Current y velocity so the object can speed up

        //Gets the a True when the Space bar is Pressed
        //Checks weather the Player Object is on the ground
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            character2D.velocity = new Vector2(character2D.velocity.x, jumpSpeed);
            grounded = false;

            Debug.Log("Jump");
            //Sets Grounded Boolean to false
        }
        
    }

    //*******************//
    // Collions Funtions //
    //*******************//
    //Called when an incoming collider makes contact with this object's collider.
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks to make sure that the tag of the object is "Floor"
        if (collision.gameObject.tag == "Floor")
        {
            //Debug.Log("ON THE FLOOR");
            grounded = true;
        }
    }
}