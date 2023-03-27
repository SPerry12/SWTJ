using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour {
    
    public int ItemID;
    public TextMeshProUGUI PriceTxt;
    public TextMeshProUGUI QuantityTxt;
    public GameObject ShopManager;

    public bool isSell;

 

    void Update() {
        
        QuantityTxt.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[3,ItemID].ToString();

        if(isSell) {
            PriceTxt.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[4,ItemID].ToString();
        }
        else {
            PriceTxt.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[2,ItemID].ToString();
        }
    }
}
