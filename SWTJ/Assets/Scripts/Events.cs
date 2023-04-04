using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{

    public Player player;
    public void randomEvent() {
        int randomSeed = Random.Range(1,3);

        switch(randomSeed){
            default:
                case 1: lostCargo();
                break;
                case 2: lostHealth();
                break;
        }
    }

    public void lostCargo() {
        Debug.Log("Lost cargo");
    }

    public void lostHealth() {
        player.health--;
        player.setHealth();

        if(player.health <= 0) {
            SceneManager.LoadScene("GameOver");
        }
    }
}
