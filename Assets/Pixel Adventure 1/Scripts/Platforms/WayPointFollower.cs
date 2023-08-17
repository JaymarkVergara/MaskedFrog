using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{   //type of game object
   [SerializeField] private GameObject []waypoints; 
   //to know what waypoints we currently moving
   private int currentWayPointsIndex = 0;
    [SerializeField] private float speed = 2.2f;
   //will put the way point once start
    //this time we dont move our object to velocity
    //we want to set the position directly frame by frame

    
    //write some logic to set the position of our moving platform each frame
    void Update()
    {   //this way we can check the distance of between the platform and currently active waypoint
        //to know we get close to it or touch it
        //we want to switch to next waypoints so we can move it
        //calculate the distance between vectors
        //first vector position curently active waypoint and pos of moving playform
        //if the distance is 0 we want to switch by next wavepoint
        //return true or false eaech frame
        //we need to switch to the first one
        if(Vector2.Distance(waypoints[currentWayPointsIndex].transform.position, transform.position) < .1f){

            currentWayPointsIndex++;
            if(currentWayPointsIndex >=waypoints.Length){
                currentWayPointsIndex = 0;
            }

        }
        //we want to move our platform a little bit to next way point
        //define how many game units we want to move our platform
        //when we call method we set value 
        //we dont want move 2 game units in 1 frame
        //we want to move by seconds
        //time delta fractions of seconds that has pass since the last frame
        //frame rate high value low framerate low value high 
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPointsIndex].transform.position, Time.deltaTime * speed);

    }
}
