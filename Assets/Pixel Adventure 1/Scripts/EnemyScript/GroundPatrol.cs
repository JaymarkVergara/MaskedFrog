using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPatrol : MonoBehaviour
{
    public float moveSpeed;
    private bool moveLeft;
    public Transform contactChecker;
    private float rayLength = 1f;
    private SpriteRenderer sprite;
    private Animator anim;
    void Start()
    {
        moveLeft = true;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       //how we move
       transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }   

    //physics element
    void FixedUpdate(){
          int layerMask = 1 << 9;
        //~ is not
        layerMask =  ~ layerMask;
        //point of origiin and length of our beam
        RaycastHit2D contactCheck = Physics2D.Raycast(contactChecker.position, Vector2.left, rayLength,layerMask);
       //ask some quetions
        if(contactCheck == true){
            //am i moving left
            
            
            if(moveLeft == true){
                transform.eulerAngles  = new Vector2(0,180);
                //moving right no longer moving left
                moveLeft = false;
                sprite.flipX = false;
               
            }
            else{
                    
                      sprite.flipX = false;
               
                //turn around
                 transform.eulerAngles  = new Vector2(0,0);
                   moveLeft = true;
                  
            }
        }
    }
}
