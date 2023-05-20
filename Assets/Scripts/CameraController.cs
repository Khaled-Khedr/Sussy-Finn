using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform player; //we cant use getcomponent since its in the player obv not camera so we use the editor and drag player in the field.

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z); //no need to get component for transform unity does it for u

    }//so player position changes so we get the player position at x axis y axis for z it never changes so we get the transform position from unity eg. -10 
}