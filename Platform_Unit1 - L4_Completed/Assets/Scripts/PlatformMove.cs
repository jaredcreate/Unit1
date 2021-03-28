using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    //Variables Right and Left Position of the Movement
    public float posX1, posX2 = 0.0f;

    //Sets the Movement Speed for the Platform
    public float movespeed = 4.0f;
    //Boolean for Movement Direction
    bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        //Go To the Starting Position
        transform.position = new Vector2(posX1, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("moveRight: " + moveRight);

        //Controls Right to Left Boolean for Movement Direction 
        if (transform.position.x >= posX2)
        {
            moveRight = false;
        }
        if (transform.position.x < posX1)
        {
            moveRight = true;
        }

        //Controls Right to Left Movement based on the moveRight Boolean
        if (moveRight == true)
        {
            transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - movespeed * Time.deltaTime, transform.position.y);
        }
    }

}
