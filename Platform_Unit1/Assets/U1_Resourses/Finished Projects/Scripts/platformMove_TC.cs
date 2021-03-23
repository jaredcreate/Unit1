using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove_TC : MonoBehaviour
{
    // Start is called before the first frame update
    public float posX1, posX2 = 0.0f;
    public float movespeed = 4.0f;
    bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(posX1, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("moveRight: " + moveRight);
        if (transform.position.x >= posX2)
        {
            moveRight = false;
        }
        if (transform.position.x < posX1)
        {
            moveRight = true;
        }
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
