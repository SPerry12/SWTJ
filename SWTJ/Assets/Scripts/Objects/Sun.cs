using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sun : MonoBehaviour
{

    public Player player;

    private void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.tag.Equals("Player") == true) {
            SceneManager.LoadScene("GameOver");
            Debug.Log("Collision!");  
        }
        
    }
}
