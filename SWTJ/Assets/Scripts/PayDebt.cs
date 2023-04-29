using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PayDebt : MonoBehaviour
{
    public GameObject debtMenu;
    public Player player;

    void Start() {
        debtMenu.SetActive(false);
    }

    public void openMenu() {
        debtMenu.SetActive(true);
    }

    public void closeMenu() {
        debtMenu.SetActive(false);
    }

    public void payDebt() {
        if(player.coinAmount >= 10000) {
            player.debtAmount -= 10000;
            player.coinAmount -= 10000;
            
            if(player.debtAmount <= 0) {
                SceneManager.LoadScene("Win");
            }
            

            player.setCoinTxt();
            player.setDebtTxt();
        }
    }
}
