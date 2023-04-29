using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackText;
    public bool isPlayer;



    void Start() {
        if(isPlayer) {
            int loadedHealth = PlayerPrefs.GetInt("playerHealth");
            healthText.text = "Health: " + loadedHealth.ToString();
        }
        
    }

    public void SetHUD(EnemyCombat enemyCombat) {
        nameText.text = enemyCombat.unitName;
        healthText.text = "Health: " + enemyCombat.currentHP.ToString();
        attackText.text = "Attack: " + enemyCombat.damage.ToString();
    }
}
