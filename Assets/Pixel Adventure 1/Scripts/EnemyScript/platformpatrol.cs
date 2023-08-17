using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformpatrol : MonoBehaviour
{
    public float moveSpeed;
    private bool moveLeft;
    public Transform contactChecker;
    private float rayLength = 1f;
    private SpriteRenderer sprite;
    void Start()
    {
        moveLeft = true;
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
        //to create a bit ship
        //then the number of layer we want to use
        //our raycast only worked with this
        //to affect everylayer execept player
        int layerMask = 1 << 9;
        //~ is not
        layerMask =  ~ layerMask;
        //ignore this layer
        //point of origiin and length of our beam
        //invisible beam
        RaycastHit2D contactCheck = Physics2D.Raycast(contactChecker.position, Vector2.down, rayLength, layerMask);
       //bot touching ground
        if(contactCheck == false){
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
