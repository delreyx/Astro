using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
   public void LoadScene(int i)
   {
    SceneManager.LoadScene(i);
   }

   public void quit() 
   {
      Application.Quit();
   }
}
