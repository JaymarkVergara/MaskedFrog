using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public string levelToLoad = "";
    public int lives;
    public int currentcoins;
    public GameObject fadeout;
    public GameObject guides;
    [SerializeField] private AudioSource gameStartSfx;
 
    
    void Start(){
        PlayerPrefs.SetInt("CurrentLives", lives);
        PlayerPrefs.SetInt("SaveCoins", currentcoins);
    }
    public void PlayGame(){
        gameStartSfx.Play();
        fadeout.SetActive(true);
        StartCoroutine("LoadNa");
    }
     private IEnumerator LoadNa(){
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(levelToLoad);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void Guides(){
        guides.SetActive(true);
    }
    public void back(){
         guides.SetActive(false);
    }
}
