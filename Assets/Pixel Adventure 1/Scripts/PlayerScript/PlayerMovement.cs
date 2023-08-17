using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   //for physic movement x and y
    private Rigidbody2D rigidBody;
    private BoxCollider2D colision;
    //for flip
    private SpriteRenderer sprite;
    //these are for reference in component
    private Animator anim;
    private float directionX = 0f;
    
    //public the variable we can edit on inspector
    [SerializeField] private LayerMask jumpAbleGround;
    [SerializeField]private float moveSpeed = 8f;
    [SerializeField]public float jumpForce = 13f;
    [SerializeField] public float defaultJump;

    // we can create our own variable;
    private enum MovementState{idle, running, jumping, falling };
    //can hold either one of the value
    [SerializeField] private AudioSource jumpSfx;

    // Start is called before the first frame update
    void Start()
    {
   
    rigidBody = GetComponent<Rigidbody2D>();
    colision = GetComponent<BoxCollider2D>();
    sprite = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
    defaultJump = jumpForce; 
    }

    // Update is called once per frame
    void Update()
    {   
        //for left and right get input from input manager
        directionX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(directionX * moveSpeed, rigidBody.velocity.y);
        
        if(Input.GetButtonDown("Jump") && IsGrounded()){
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpForce);
            jumpSfx.Play();

        }
        
        UpdateAnimationState();
    }

 
    private void UpdateAnimationState(){
        MovementState state;

         if(rigidBody.velocity.x > 0f){
            state = MovementState.running;
             sprite.flipX = false;
         }
         else if(rigidBody.velocity.x < 0f){
            state = MovementState.running;
            sprite.flipX = true;
         }
         else{
           state = MovementState.idle;
         }

         if(rigidBody.velocity.y > .1f){
            state = MovementState.jumping;
         }
         else if(rigidBody.velocity.y < -.1f){
            state = MovementState.falling;
         }
         //we can call in on it one time

         anim.SetInteger("state", (int)state) ;
    }

    //we can use the function isground to check if the box over lap the ground
    private bool IsGrounded(){
         //we create a box around our player that has same shape as box collider
        //box center size and its position the seconds box over
        //it bassicaly 0f no rotate v2down .1f the position of box wil go down slight
        //now checks if we overlapping in the jumpableground
        //box cast returns voolean
        return Physics2D.BoxCast(colision.bounds.center, colision.bounds.size, 0f, Vector2.down, .1f,jumpAbleGround );
    }
       
        

}
