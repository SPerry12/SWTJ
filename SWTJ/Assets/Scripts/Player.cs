using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour{
    

    public int health;

    public TextMeshProUGUI healthTxt;


    public void Start() {
        healthTxt.text = "Health: " + health.ToString();
    }

    public void setHealth() {
        healthTxt.text = "Health: " + health.ToString();
    }

}
