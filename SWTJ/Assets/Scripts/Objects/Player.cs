using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour{
    

    public int health;
    public int coinAmount;
    public int fuelAmount;
    public int oreAmount;
    public int luxuryAmount;
    public int gemAmount;
    public int debtAmount;

    public TextMeshProUGUI healthTxt;
    public TextMeshProUGUI coinTxt;
    public TextMeshProUGUI fuelTxt;
    public TextMeshProUGUI oreTxt;
    public TextMeshProUGUI luxuryTxt;
    public TextMeshProUGUI gemTxt;
    public TextMeshProUGUI debtTxt;
    public GameObject player;
    public GameObject combatVictoryMenu;

    public Vector3 playerPosition;
    public ShopManagerScript shopManagerScript;
    public SaveLoad saveLoad;

    public TextMeshProUGUI recoveredHealth;
    public TextMeshProUGUI recoveredCoins;
    public TextMeshProUGUI recoveredFuel;
    public TextMeshProUGUI recoveredOre;
    public TextMeshProUGUI recoveredLuxury;
    public TextMeshProUGUI recoveredGem;

    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "health") {
            int randomSeed = Random.Range(1,5);
            health += randomSeed;
            setHealth();
            PlayerPrefs.SetInt("playerHealth", health);
            GetComponent<AudioSource>().Play();
        }   

        if(other.tag == "AI") {
            PlayerPrefs.SetFloat("playerX", player.transform.position.x);
            PlayerPrefs.SetFloat("playerY", player.transform.position.y);
            PlayerPrefs.SetInt("playerCoins", coinAmount);
            PlayerPrefs.SetInt("playerFuel", fuelAmount);
            PlayerPrefs.SetInt("playerOre", oreAmount);
            PlayerPrefs.SetInt("playerLuxury", luxuryAmount);
            PlayerPrefs.SetInt("playerGem", gemAmount);
            PlayerPrefs.SetInt("playerDebt", debtAmount);
        }     
    }


    public void Start() {
        string isLoaded = PlayerPrefs.GetString("isLoaded");
        string battleReturn = PlayerPrefs.GetString("battleResult");
        Debug.Log(battleReturn);
        combatVictoryMenu.SetActive(false);
        if(isLoaded.Equals("true")) {
            saveLoad.Load();
        } else if(battleReturn.Equals("win")) {
            Vector3 newPosition = new Vector3(PlayerPrefs.GetFloat("playerX"), PlayerPrefs.GetFloat("playerY"), 0f);
            transform.position = newPosition;


            int winFuel = Random.Range(1,5);
            int winCoin = Random.Range(100,200);
            int winOre = Random.Range(0,4);
            int winLuxury = Random.Range(0,3);
            int winGem = Random.Range(0,2);
            int winHealth = Random.Range(1,5);

            setHealthAmount(PlayerPrefs.GetInt("playerHealth") + winHealth);
            setCoinAmount(PlayerPrefs.GetInt("playerCoins") + winCoin);
            setFuelAmount(PlayerPrefs.GetInt("playerFuel") + winFuel);
            setOreAmount(PlayerPrefs.GetInt("playerOre") + winOre);
            setLuxuryAmount(PlayerPrefs.GetInt("playerLuxury") + winLuxury);
            setGemAmount(PlayerPrefs.GetInt("playerGem") + winGem);
            setDebtAmount(PlayerPrefs.GetInt("playerDebt"));
            

            recoveredHealth.text = "Health: " + winHealth;
            recoveredFuel.text = "Fuel: " + winFuel;
            recoveredGem.text = "Gem: " + winGem;
            recoveredLuxury.text = "Luxury: " + winLuxury;
            recoveredOre.text = "Ore: " + winOre;
            recoveredCoins.text = "Coins: " + winCoin;

            PlayerPrefs.SetString("battleResult", "null");
            combatVictoryMenu.SetActive(true);

        } else if(battleReturn.Equals("flee")){
            Vector3 newPosition = new Vector3(PlayerPrefs.GetFloat("playerX"), PlayerPrefs.GetFloat("playerY"), 0f);
            transform.position = newPosition;
            
            setHealthAmount(PlayerPrefs.GetInt("playerHealth"));
            setCoinAmount(PlayerPrefs.GetInt("playerCoins"));
            setFuelAmount(PlayerPrefs.GetInt("playerFuel"));
            setOreAmount(PlayerPrefs.GetInt("playerOre"));
            setLuxuryAmount(PlayerPrefs.GetInt("playerLuxury"));
            setGemAmount(PlayerPrefs.GetInt("playerGem"));
            setDebtAmount(PlayerPrefs.GetInt("playerDebt"));
        } 
        else {
            setHealth(); 
            setCoinTxt();
            setFuelTxt();
            setOreTxt();
            setLuxuryTxt();
            setGemTxt();
            setDebtTxt();

            PlayerPrefs.SetInt("playerHealth", health);
            transform.position = playerPosition;
        }

        PlayerPrefs.SetString("isLoaded", "false");

        
    }


    public void setDebtTxt() {
        debtTxt.text = "Debt: " + debtAmount.ToString();
        PlayerPrefs.SetInt("playerDebt", debtAmount);
    }

    public void setHealth() {
        healthTxt.text = "Health: " + health.ToString();
    }

    public void setCoinTxt() {
        coinTxt.text = "Coins: " + coinAmount.ToString();
        PlayerPrefs.SetInt("playerCoins", coinAmount);
    }

    public void setFuelTxt() {
        fuelTxt.text = "Fuel: " + fuelAmount.ToString();
        PlayerPrefs.SetInt("playerFuel", fuelAmount);
    }

    public void setOreTxt() {
        oreTxt.text = "Ore: " + oreAmount.ToString();
        PlayerPrefs.SetInt("playerOre", oreAmount);
    }

    public void setLuxuryTxt() {
        luxuryTxt.text = "Luxury: " + luxuryAmount.ToString();
        PlayerPrefs.SetInt("playerLuxury", luxuryAmount);
    }

    public void setGemTxt() {
        gemTxt.text = "Gems: " + gemAmount.ToString();
        PlayerPrefs.SetInt("playerGem", gemAmount);
    }

    public Vector3 getPlayerPosition() {
        Vector3 playerPosition = player.transform.position;
        return playerPosition;
    }

    public void setHealthAmount(int newHealth) {
        health = newHealth;
        setHealth();
    }
    
    public void setFuelAmount(int newFuel) {
        fuelAmount = newFuel;
        shopManagerScript.shopItems[3,1] = newFuel;
        setFuelTxt();
    }

    public void setOreAmount(int newOre) {
        oreAmount = newOre;
        shopManagerScript.shopItems[3,2] = newOre;
        setOreTxt();
    }

    public void setLuxuryAmount(int newLuxury) {
        luxuryAmount = newLuxury;
        shopManagerScript.shopItems[3,3] = newLuxury;
        setLuxuryTxt();
    }

    public void setGemAmount(int newGem) {
        gemAmount = newGem;
        shopManagerScript.shopItems[3,4] = newGem;
        setGemTxt();
    }

    public void setPlayerPosition(Vector3 newPosition) {
        transform.position = newPosition;
    }

    public void setCoinAmount(int newCoin) {
        coinAmount = newCoin;
        setCoinTxt();
    }

    public void setDebtAmount(int newDebt) {
        debtAmount = newDebt;
        setDebtTxt();
    }


}
