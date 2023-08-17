

using UnityEngine;
using UnityEngine.SceneManagement;
public class menusystem : MonoBehaviour
{     
     
      public string nextLevel;

      public  void Start()
    {
       
       
        
    }
   /*public void Replayna(){
        
      //call reset function of gamemanager by using findobjecttype gamemanager
       FindObjectOfType<GameManager>().Reset();
   }*/
    public void Quitna(){
    Application.Quit();
   }

   public void Win(){
         SceneManager.LoadScene(nextLevel);
   }

}
