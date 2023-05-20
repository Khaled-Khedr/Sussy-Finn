using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{


    [SerializeField] private float speed= 2f; //value decides how many times we rotate the image by 360 degrees per sec
    private void Update()
    {
        transform.Rotate(0, 0, 360*speed*Time.deltaTime); //360 x 2f frame independent per sec
    }
}
