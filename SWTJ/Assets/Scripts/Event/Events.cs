using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    public TextMeshProUGUI eventTitle;
    public TextMeshProUGUI eventInfo;
    public TextMeshProUGUI buttonTxt;
    public GameObject eventButton1;
    public GameObject eventButton2;
    public TextMeshProUGUI buttonTxt2;

    public Player player;
    public ShopManagerScript shopManagerScript;

    public GameObject eventCanvas;

    void Start() {
        GenerateEvents();
    }

    public void GenerateEvents() {
        StartCoroutine(GenerateEventRoutine());
        
        IEnumerator GenerateEventRoutine() {
            while(true) {
                randomEvent();
                yield return new WaitForSeconds(30f);
            }
        }
    }


    public void randomEvent() {
        int randomSeed = Random.Range(1,200);

        if(randomSeed <= 10) {
            lostCargo();
        }
        else if(randomSeed <= 20 && randomSeed > 10) {
            lostHealth();
        }
        else if(randomSeed <= 30 && randomSeed > 20) {
            distressSignal();
        }
        else if(randomSeed <= 40 && randomSeed > 30) {
            guestsBoard();
        }
    }

    private void guestsBoard()
    {
        eventCanvas.SetActive(true);
        eventButton2.SetActive(true);
        buttonTxt2.text = "Allow boarding";
        eventTitle.text = "Unexpected Guests";
        eventInfo.text = "A space craft signals they would like to board your ship. What would you like to do?";
    }

    public void allowBoarding() {
        int randomSeed = Random.Range(1,10);

        if (randomSeed < 8)
        {
            eventInfo.text = "Alien traders thank you for your hospitality +500 gold";
            player.coinAmount += 500;
            player.setCoinTxt();
            eventButton2.SetActive(false);
        }
        else {
            eventInfo.text = "Space pirates raid your ship -5 health -200 gold";
            player.coinAmount -= 200;
            player.setCoinTxt();
            player.health -= 5;
            player.setHealth();
            PlayerPrefs.SetInt("playerHealth", player.health);
            eventButton2.SetActive(false);

            if(player.health <= 0) {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    private void distressSignal() {
        eventCanvas.SetActive(true);
        eventButton1.SetActive(true);
        buttonTxt.text = "Investigate";
        eventTitle.text = "Distress Signal";
        eventInfo.text = "You pick up a distress signal from a nearby vessel. What would you like to do?";
    }

    public void distressSignal2() {
        int randomSeed = Random.Range(1,10);

        if(randomSeed < 9) {
            eventInfo.text = "You make communication with the vessel and help them with their hyper drive. You recieve +100 coins";
            player.coinAmount += 100;
            player.setCoinTxt();
            eventButton1.SetActive(false);   
        }
        else{
            eventInfo.text = "Upon reaching the vessel space pirates swam in on all sides blasting your ship -4 health!";
            player.health -= 4;
            player.setHealth();
            PlayerPrefs.SetInt("playerHealth", player.health);
            eventButton1.SetActive(false);   

            if(player.health <= 0) {
                SceneManager.LoadScene("GameOver");
            }

        }
    }

    public void lostCargo() {
        int randomItem = Random.Range(1,4);
        if (shopManagerScript.shopItems[3,randomItem] > 0){
            eventCanvas.SetActive(true);
        
            eventTitle.text = "Lost Cargo";
            shopManagerScript.shopItems[3,randomItem]--;

            switch(randomItem) {
                case 1: {
                    eventInfo.text = "Crew mismanaged cargo -1 fuel";
                    player.fuelAmount--;
                    player.setFuelTxt();
                }
                break;
                case 2: {
                    eventInfo.text = "Crew mismanaged cargo -1 ore";
                    if(player.oreAmount > 0) {
                        player.oreAmount--;
                    }
                    player.setOreTxt();
                }
                break;
                case 3: {
                    eventInfo.text = "Crew mismanaged cargo -1 luxury good";
                    if(player.luxuryAmount > 0) {
                        player.luxuryAmount--;
                    }
                    player.setLuxuryTxt();
                }
                break;
                case 4: {
                    eventInfo.text = "Crew mismanaged cargo -1 gem";
                    if(player.gemAmount > 0) {
                        player.gemAmount--;
                    }
                    player.setGemTxt();
                }
                break;
            }   
        }
    }

    public void lostHealth() {
        eventCanvas.SetActive(true);
        player.health--;
        player.setHealth();
        PlayerPrefs.SetInt("playerHealth", player.health);

        if(player.health <= 0) {
            SceneManager.LoadScene("GameOver");
        }

        eventTitle.text = "Ship Damaged!";
        eventInfo.text = "An astroid has crashed into your ship -1 health";
    }

    public void closeUI(){
        eventCanvas.SetActive(false);
        eventButton1.SetActive(false);
    }
}
