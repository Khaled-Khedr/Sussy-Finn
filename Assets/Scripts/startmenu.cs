using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startmenu : MonoBehaviour
{
    public AudioSource MenuMusic;
    public void startgame ()
    {
        MenuMusic.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

}
