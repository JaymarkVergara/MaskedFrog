using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPlatform : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision){
    //this time we dont need to detech other player because we only one player
    //compare the name diretcly
    if(collision.gameObject.name == "Player"){
 //execute of this stickyplatform collides with other collider 
 //if the collider has the name player
 //we want to put the player inside the moving platform as a child
 //game object we collided 
 //method what we want to set parent of gameobject 
 //pass transform transform of the sticky compponent
    collision.gameObject.transform.SetParent(transform);
    }
  }

  private void OnTriggerExit2D(Collider2D collision){
      if(collision.gameObject.name == "Player"){
    collision.gameObject.transform.SetParent(null);
    }
  }

}
