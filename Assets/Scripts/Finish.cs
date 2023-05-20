using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{

    private AudioSource finishSound;

    private bool levelCompleted = false; //so we fix a bug when u walk away from the finish line 
   private void Start()
    {
        finishSound = GetComponent<AudioSource>(); //since we need the audio source once 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f); //invoke calls the functions 2 sec after u trigger the finish line
            
            
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }




}
