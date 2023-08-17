using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public PlayerMovement thePlayer;
    private Vector2 playerStart;
    [SerializeField] public GameObject victoryScreen;
    [SerializeField] public GameObject gameOverScreen;
   
    public Rigidbody2D rigidBody;
    [SerializeField] private AudioSource deathSfx;
    public string mainmenu;
    private GameManager GameManagerGet;
    public int coins = 0;
    private PlayerLife anim;
    [SerializeField] private GameObject fadeout;
     [SerializeField] private GameObject fadein;
    [SerializeField] private Text totalcoins;

  public  void Start(){       
        //reference where game start position of the player
        //it alwayss gonna gave reference on position of the player
        playerStart = thePlayer.transform.position;
        GameManagerGet = FindObjectOfType<GameManager>();
        anim = FindObjectOfType<PlayerLife>();
        fadein.SetActive(true);
    }

      public void Reset(){
        thePlayer.gameObject.SetActive(true);
        //game drop our player position
        thePlayer.transform.position = playerStart;  
        gameOverScreen.SetActive(false);
    }
    
      public void GameOver(){
        deathSfx.Play();

        rigidBody.bodyType = RigidbodyType2D.Static;
        fadeout.SetActive(true);
        coins = PlayerPrefs.GetInt("SaveCoins");
        totalcoins.text = "Total:"+ coins; 
        StartCoroutine("GameReset");  
    }
       private IEnumerator GameReset(){
        yield return new WaitForSeconds(1);
        deathSfx.Stop();
        gameOverScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        gameOverScreen.SetActive(true);
        SceneManager.LoadScene(mainmenu);
    }

     public void Victory(){
        fadeout.SetActive(true);
        StartCoroutine("vic");
    }
     IEnumerator vic(){
        yield return new WaitForSeconds(1);
        victoryScreen.SetActive(true);
    }
     public void Victory2(){
        fadeout.SetActive(true);
        StartCoroutine("vic2");
        coins = PlayerPrefs.GetInt("SaveCoins");
        totalcoins.text = "Total:"+ coins; 
    }
      IEnumerator vic2(){
        yield return new WaitForSeconds(1);
        victoryScreen.SetActive(true);
        yield return new WaitForSeconds(6);
        fadeout.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(mainmenu);
    }

   
     //start courutine delay the execution of something give more control the time when want to run
        //numerator
 
  

   
   


}
