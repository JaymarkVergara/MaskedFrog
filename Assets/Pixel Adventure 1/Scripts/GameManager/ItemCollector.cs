using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    //set our box collider on trigger
    //unity pass a collision argument here
    //contains information what we colide with
 
   
    //count banana
    //we dont want to put ontrigger2d because then newly created everytime this function caled back to zero again
     public int coins = 0;

   
   

    [SerializeField] private AudioSource collectSfx;
   
    [SerializeField] private Text coinTxt;

    

     void Start(){
        if(PlayerPrefs.HasKey("SaveCoins")){
            coins = PlayerPrefs.GetInt("SaveCoins");
            coinTxt.text = ""+ coins; 
            
        }
      

    
      
       
    }

  
    private void OnTriggerEnter2D(Collider2D collision){
        //if we colide on cherries we wanna execute the code 
        if(collision.gameObject.CompareTag("Coins")){
            //pass the object we want to destroy
            Destroy(collision.gameObject);
            coins++;
            collectSfx.Play();
            coinTxt.text = ""+ coins; 
            PlayerPrefs.SetInt("SaveCoins", coins);
            
        }
    }


    

}
