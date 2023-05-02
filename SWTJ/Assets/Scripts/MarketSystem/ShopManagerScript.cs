using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];
    public GameObject BuyItem;
    public GameObject SellItem;
    
    Planet planet = new Planet();
    public Player player;


    private void Awake() {
        BuyItem.SetActive(false);
        SellItem.SetActive(false);
    }

    void Start()
    {
        //ID's
        shopItems[1,1] = 1; // Fuel
        shopItems[1,2] = 2; // Ore
        shopItems[1,3] = 3; // Luxury
        shopItems[1,4] = 4; // Gems

        //Buy Price
        shopItems[2, 1] =  planet.getPlanetBuyPrice(shopItems[1,1]); 
        shopItems[2, 2] =  planet.getPlanetBuyPrice(shopItems[1,2]);
        shopItems[2, 3] =  planet.getPlanetBuyPrice(shopItems[1,3]);
        shopItems[2, 4] =  planet.getPlanetBuyPrice(shopItems[1,4]);
        
        //QuantityS
        shopItems[3, 1] = player.fuelAmount;
        shopItems[3, 2] = player.oreAmount;
        shopItems[3, 3] = player.luxuryAmount;
        shopItems[3, 4] = player.gemAmount;

        //Sell Price
        shopItems[4, 1] = planet.getPlanetSellPrice(shopItems[1,1]);
        shopItems[4, 2] = planet.getPlanetSellPrice(shopItems[1,2]);
        shopItems[4, 3] = planet.getPlanetSellPrice(shopItems[1,3]);
        shopItems[4, 4] = planet.getPlanetSellPrice(shopItems[1,4]);

    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        
        if (player.coinAmount >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]) {
            player.coinAmount -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;

            int itemId = ButtonRef.GetComponent<ButtonInfo>().ItemID;
            updateCargo(itemId);

            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            ButtonRef.GetComponent<AudioSource>().Play();

        }
    }

    public void Sell() {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        
        if (shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] > 0) {
            player.coinAmount += shopItems[4, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]--;
            
            int itemId = ButtonRef.GetComponent<ButtonInfo>().ItemID;
            updateCargo(itemId);
           
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            ButtonRef.GetComponent<AudioSource>().Play();
        }
    }

    private void updateCargo(int itemId) {
         player.setCoinTxt();
            switch(itemId) {
                case 1: 
                player.fuelAmount = shopItems[3,1];
                player.setFuelTxt();
                break;
                case 2: 
                player.oreAmount = shopItems[3,2];
                player.setOreTxt();
                break;
                case 3: 
                player.luxuryAmount = shopItems[3,3];
                player.setLuxuryTxt();
                break;
                case 4: 
                player.gemAmount = shopItems[3,4];
                player.setGemTxt();
                break;
            }
    }

               
            
            

}
