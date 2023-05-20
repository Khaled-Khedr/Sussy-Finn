using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{

    private Button quitbutton;

    public void Start()
    {
        quitbutton = GetComponent<Button>();
        quitbutton.onClick.AddListener(QuitGame);

    }
    public void QuitGame()
    {

        Application.Quit();
    }
 
}
