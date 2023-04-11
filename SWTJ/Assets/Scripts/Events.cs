using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Events : MonoBehaviour
{
    public TextMeshProUGUI eventTitle;
    public TextMeshProUGUI eventInfo;

    public Player player;

    public GameObject eventCanvas;

    public void randomEvent() {
        int randomSeed = Random.Range(1,2000);
        Debug.Log("This is random seed: " + randomSeed);

        switch(randomSeed){
            case 1: lostCargo();
            break;
            case 2: lostHealth();
            break;
        }
    }

    public void lostCargo() {
        eventCanvas.SetActive(true);
        eventTitle.text = "Lost Cargo";
        eventInfo.text = "Crew mismanaged cargo -1 supply";
        
    }

    public void lostHealth() {
        eventCanvas.SetActive(true);
        player.health--;
        player.setHealth();

        if(player.health <= 0) {
            SceneManager.LoadScene("GameOver");
        }

        eventTitle.text = "Ship Damaged!";
        eventInfo.text = "An astroid has crashed into your ship -1 health";
    }

    public void closeUI(){
        eventCanvas.SetActive(false);
    }
}
