
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigidBody;
     public GameManager GameManagerGet;
     public GameObject player;
    private LivesManager lm;
    private bosscontrol bc;
   

    
    
    [SerializeField] private AudioSource deathSfx;
    // Start is called before the first frame update
    void Start()
    {
       
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        lm = FindObjectOfType<LivesManager>();

        bc = FindObjectOfType<bosscontrol>();
        
    }
   

   
    //we can get info what we collided
    public void OnCollisionEnter2D(Collision2D collision){
      //to distinguish what we collision add tag
    if(collision.gameObject.CompareTag("trap") || collision.gameObject.CompareTag("Enemy") ){
           
        
         lm.TakeLife();
         Die();
    }
    }

     public void OnTriggerEnter2D(Collider2D collision){
         if(collision.gameObject.CompareTag("trap") || collision.gameObject.CompareTag("Enemy") ){
    
            
         lm.TakeLife();
         Die();
    

    }
     }

    public void Die(){
        //execute this trigger animtor swtich to death anim
        rigidBody.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        deathSfx.Play();
        Invoke("BackToIdle", 1f);
       
    }

    public void animdie(){
         anim.SetTrigger("death");
    }

     public void BackToIdle(){
        
        GameManagerGet.Reset();
         rigidBody.bodyType = RigidbodyType2D.Dynamic;
         // GameManagerGet.GameOver();
            anim.SetTrigger("Idle");
            


        
    }

    
    
 
}
