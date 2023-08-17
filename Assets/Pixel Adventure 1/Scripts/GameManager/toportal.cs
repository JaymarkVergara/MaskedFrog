using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toportal : MonoBehaviour
{
    // Start is called before the first frame update
            private GameManager gm;
            [SerializeField]   private string nextLevels;
            [SerializeField]private GameObject fadeout;
 
    void Start()
    {
            gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
 
     private void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("Player")){
        fadeout.SetActive(true);
        StartCoroutine("toboss");
         }
   }

   

    IEnumerator toboss(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevels);
    }
  
}
