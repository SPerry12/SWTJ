using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject tutorialX;

    void Start() {
        string battleReturn = PlayerPrefs.GetString("battleResult");
        if(battleReturn.Equals("win") || battleReturn.Equals("flee")){
            tutorialX.SetActive(false);
        }else {
            tutorialX.SetActive(true);
        } 
        
    }

    public void closeMenu() {
        tutorialX.SetActive(false);
    }
}
