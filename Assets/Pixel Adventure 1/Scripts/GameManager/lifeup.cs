using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeup : MonoBehaviour
{
    private LivesManager lm;
    // Start is called before the first frame update
    void Start()
    {
        //reference for add life
        lm = FindObjectOfType<LivesManager>();
    }

        //if we colide on cherries we wanna execute the code 
     
    //other to know we use other refereing to the other game objec
    public void OnTriggerEnter2D(Collider2D other){
        
     if(other.gameObject.tag == "Player")
       
        lm.AddLife();
       Destroy(gameObject);
    }
    
}
