using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Script_TC : MonoBehaviour
{
    // Variable for Time Score
    public float timeStart = 0f;
    public Text scoreText;

    // Variable for heart Count
    public int hearts;
    public Text healthText;

    // Variable to Connect to the Player GameObject
    GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        // Find and connect to the Player Object and 
        // Connect to the Variables from the Heart Count
        playerObject = GameObject.Find("Player");
        hearts = playerObject.GetComponent<PlayerControl_TC>().playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for Heart Count 
        if (true)
        {
            // Update the Heart Count 
            hearts = playerObject.GetComponent<PlayerControl_TC>().playerHealth;

            // Time Count
            timeStart = timeStart + Time.deltaTime;

            // Set the Score and the Heart Count to the GUI Text of the Text Objects 
            healthText.text = ("HEARTS: " + hearts.ToString());
            scoreText.text = ("SCORE: " + Mathf.Round(timeStart).ToString());

        }
    }
}





