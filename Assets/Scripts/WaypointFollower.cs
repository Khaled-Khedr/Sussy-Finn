using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int CurrentWaypointIndex=0;


    [SerializeField] private float speed = 5f; //we move 2 OR 5 (more speed )game units per second cause of delta time aka the squares 
    private void Update()
    {
       if (Vector2.Distance(waypoints[CurrentWaypointIndex].transform.position, transform.position) < .1f) //vector2.Distance calculates the distance between the platform and the waypoints if its less than .1f 
        {
            CurrentWaypointIndex++;

            if (CurrentWaypointIndex >= waypoints.Length) //if we reach the last waypoint we reset the array (waypoints.length size of the waypoints array)
            {
                CurrentWaypointIndex = 0;
            }
        
        }


        transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentWaypointIndex].transform.position, Time.deltaTime * speed); //delta time makes sure we dont move the platform to the waypoints instantly but over a period of time 

    }
}
