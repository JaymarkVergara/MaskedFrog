using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] private float duration = 2f;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

   private void OnTriggerEnter2D(Collider2D other ){
    if(other.gameObject.tag == "Player"){
        StartCoroutine("JumpBoostDuration");
    }
   }

   IEnumerator JumpBoostDuration()
   {    
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        player.jumpForce += 5f;
        yield return new WaitForSeconds(duration);
        player.jumpForce = player.defaultJump; 
        Destroy(gameObject);
   }
}
