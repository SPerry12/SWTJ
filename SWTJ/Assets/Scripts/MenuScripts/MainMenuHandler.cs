using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
 
   public void StartGame() {
      PlayerPrefs.SetString("isLoaded", "false");
      SceneManager.LoadScene("Main");
   }

   public void loadGame() {
      PlayerPrefs.SetString("isLoaded", "true");
      SceneManager.LoadScene("Main");
   }
}
