using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ChestScript : MonoBehaviour
{
    //Create Scene Variables
    public string scenename;
    public Scene scene;

    //Create an Win Event for the UI PlayerWin
    public UnityEvent winEvent;

    private void Start()
    {
        //Get Current Scene Name
        scene = SceneManager.GetActiveScene();
        scenename = scene.name;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Collider Check        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("GameObject1 collided with " + collision.name);

            //Check Current Scene if Level 1   
            if (scenename == "Lesson 4 Level1")
            {
                SceneManager.LoadScene("Lesson 4 Level2");
            }
            //Check Current Scene if Level 2  
            if (scenename == "Lesson 4 Level2")
            {
                //Use winEvent to Pause the Game
                Time.timeScale = 0;
                winEvent.Invoke();
            }

        }
    }
}