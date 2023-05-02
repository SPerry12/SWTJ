using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Planet : MonoBehaviour {

    [SerializeField] private GameObject Background;
    [SerializeField] private GameObject Buy;
    [SerializeField] private GameObject Sell;
    [SerializeField] private int id;



    public ShopManagerScript shopManagerScript;

    private void Awake() {
        Background.SetActive(false);
    }

    void Start() {
        StartCoroutine(RandomPrices());
    }

    IEnumerator RandomPrices() {

        yield return new WaitForSeconds(60f);
    }
    
    private void OnTriggerEnter2D(Collider2D collider) {


        if(collider.gameObject.tag.Equals("Player") == true) {
            Background.SetActive(true);
            Buy.SetActive(true);
            Sell.SetActive(true);  
            test(id); 
        }
           
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag.Equals("Player") == true) {
            Background.SetActive(false);
            Sell.SetActive(false);
            Buy.SetActive(false);
        }
    }

    public int getPlanetBuyPrice(int itemID) {
        // Planet?
        if(id == 1) {
            switch (itemID) {
                default:
                    case 1: return 8;
                    case 2: return 45;
                    case 3: return 15;
                    case 4: return 35; 
            }
        }
        // Sand Planet
        else if(id == 2) {
            switch (itemID) {
                default:
                    case 1: return 5;
                    case 2: return 15;
                    case 3: return 45;
                    case 4: return 35; 
            }
        }
        // Planet?(2)
        else if(id == 3) {
            switch (itemID) {
                default:
                    case 1: return 2;
                    case 2: return 25;
                    case 3: return 35;
                    case 4: return 45; 
            }
        }
        // Ice_Planet
        else if(id == 4) {
            switch (itemID) {
                default:
                    case 1: return 10;
                    case 2: return 35;
                    case 3: return 25;
                    case 4: return 15; 
            }
        }
        else{
            return 0;
        }
    }

    public int getPlanetSellPrice(int itemID) {
        // Planet?
        if(id == 1) {
            switch (itemID) {
                default:
                    case 1: return 2;
                    case 2: return 40;
                    case 3: return 10;
                    case 4: return 30; 
            }
        }
        // Sand Planet
        else if(id == 2) {
            switch (itemID) {
                default:
                    case 1: return 2;
                    case 2: return 10;
                    case 3: return 40;
                    case 4: return 30; 
            }
        }
        // Planet?(2)
        else if(id == 3) {
            switch (itemID) {
                default:
                    case 1: return 1;
                    case 2: return 20;
                    case 3: return 30;
                    case 4: return 40; 
            }
        }
        // Ice_Planet
        else if(id == 4) {
            switch (itemID) {
                default:
                    case 1: return 5;
                    case 2: return 30;
                    case 3: return 20;
                    case 4: return 10; 
            }
        }
        else{
            return 0;
        }
    }      
    
    private void test(int planetId) {

            shopManagerScript = GameObject.Find("ShopManager").GetComponent<ShopManagerScript>();

            shopManagerScript.shopItems[2,1] = getPlanetBuyPrice(1);
            shopManagerScript.shopItems[2,2] = getPlanetBuyPrice(2);
            shopManagerScript.shopItems[2,3] = getPlanetBuyPrice(3);
            shopManagerScript.shopItems[2,4] = getPlanetBuyPrice(4);

            shopManagerScript.shopItems[4,1] = getPlanetSellPrice(1);
            shopManagerScript.shopItems[4,2] = getPlanetSellPrice(2);
            shopManagerScript.shopItems[4,3] = getPlanetSellPrice(3);
            shopManagerScript.shopItems[4,4] = getPlanetSellPrice(4);

        /*shopManagerScript.shopItems[4, 1] = getPlanetSellPrice(shopManagerScript.shopItems[1,1]);

        do{
            shopManagerScript.shopItems[4, 1] = getPlanetSellPrice(shopManagerScript.shopItems[1,1]);
        }while(shopManagerScript.shopItems[4,1] > shopManagerScript.shopItems[2, 1]);

        shopManagerScript.shopItems[4, 2] = getPlanetSellPrice(shopManagerScript.shopItems[1,2]);

        do{
            shopManagerScript.shopItems[4, 2] = getPlanetSellPrice(shopManagerScript.shopItems[1,2]);
        }while(shopManagerScript.shopItems[4,2] > shopManagerScript.shopItems[2, 2]);

        shopManagerScript.shopItems[4, 3] = getPlanetSellPrice(shopManagerScript.shopItems[1,3]);

        do{
            shopManagerScript.shopItems[4, 3] = getPlanetSellPrice(shopManagerScript.shopItems[1,3]);
        }while(shopManagerScript.shopItems[4,3] > shopManagerScript.shopItems[2, 3]);

        shopManagerScript.shopItems[4, 4] = getPlanetSellPrice(shopManagerScript.shopItems[1,4]);

        do{
            shopManagerScript.shopItems[4, 4] = getPlanetSellPrice(shopManagerScript.shopItems[1,4]);
        }while(shopManagerScript.shopItems[4,4] > shopManagerScript.shopItems[2, 4]);*/
        
    }
}
