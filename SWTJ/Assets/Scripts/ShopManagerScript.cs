using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];
    public float coins;
    public TextMeshProUGUI CoinstTXT;
    public TextMeshProUGUI FuelTxt;
    public TextMeshProUGUI OreTxt;
    public TextMeshProUGUI LuxuryTxt;
    public TextMeshProUGUI GemsTxt;
    public GameObject BuyItem;
    public GameObject SellItem;
    

    Planet planet = new Planet();


    private void Awake() {
        BuyItem.SetActive(false);
        SellItem.SetActive(false);
    }

    void Start()
    {
        CoinstTXT.text = "Coins:" + coins.ToString();

        //ID's
        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;

        //Buy Price
        shopItems[2, 1] =  planet.getPlanetBuyPrice(shopItems[1,1]); 
        shopItems[2, 2] =  planet.getPlanetBuyPrice(shopItems[1,2]);
        shopItems[2, 3] =  planet.getPlanetBuyPrice(shopItems[1,3]);
        shopItems[2, 4] =  planet.getPlanetBuyPrice(shopItems[1,4]);

        //QuantityS
        shopItems[3, 1] = 10;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

        //Sell Price
        shopItems[4, 1] = planet.getPlanetSellPrice(shopItems[1,1]);
        shopItems[4, 2] = planet.getPlanetSellPrice(shopItems[1,2]);
        shopItems[4, 3] = planet.getPlanetSellPrice(shopItems[1,3]);
        shopItems[4, 4] = planet.getPlanetSellPrice(shopItems[1,4]);
 
        FuelTxt.text = "Fuel: " + shopItems[3,1].ToString(); 
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        
        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]) {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinstTXT.text = "Coins:" + coins.ToString();
            FuelTxt.text = "Fuel: " + shopItems[3,1].ToString();
            OreTxt.text = "Ore: " + shopItems[3,2].ToString();
            LuxuryTxt.text = "Luxury: " + shopItems[3,3].ToString();
            GemsTxt.text = "Gems: " + shopItems[3,4].ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            ButtonRef.GetComponent<AudioSource>().Play();
        }
    }

    public void Sell() {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        
        if (shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] > 0) {
            coins += shopItems[4, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]--;
            CoinstTXT.text = "Coins:" + coins.ToString();
            FuelTxt.text = "Fuel: " + shopItems[3,1].ToString();
            OreTxt.text = "Ore: " + shopItems[3,2].ToString();
            LuxuryTxt.text = "Luxury: " + shopItems[3,3].ToString();
            GemsTxt.text = "Gems: " + shopItems[3,4].ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            ButtonRef.GetComponent<AudioSource>().Play();
        }
    }

}
