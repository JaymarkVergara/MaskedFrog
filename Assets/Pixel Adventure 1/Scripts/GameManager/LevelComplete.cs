using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private AudioSource completeSfx;
    private bool lvlComplete = false;
    [SerializeField]private GameObject fadeout;

    private GameManager gm;
    

    void Start()
    {
        
        completeSfx = GetComponent<AudioSource>();
        gm = FindObjectOfType<GameManager>();
    }

   private void OnTriggerEnter2D(Collider2D col){
    if(col.gameObject.name == "Player"){
        completeSfx.Play();
        gm.Victory2();
         }
   }

   
  


   
}
