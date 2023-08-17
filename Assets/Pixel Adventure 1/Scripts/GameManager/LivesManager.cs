
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    
    //a number represent in text
    public int livesCounter;
    public Text livesTxt;
    //reference for gamemanager overmethod
    private GameManager GameManagerGet;
    void Start(){
        livesCounter = PlayerPrefs.GetInt("CurrentLives");  
        //call upon game manager
        GameManagerGet = FindObjectOfType<GameManager>();
    }

    void Update(){
        livesTxt.text = "x " + livesCounter;
        if(livesCounter < 1){
            GameManagerGet.GameOver();
        }
    }
    public void TakeLife(){
        livesCounter--;
        //overrides current lives contantly set our curent lives value
        PlayerPrefs.SetInt("CurrentLives", livesCounter);
    }
      public void AddLife(){
         livesCounter++;
          PlayerPrefs.SetInt("CurrentLives", livesCounter);
    }
   
}
