using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Planet : MonoBehaviour {

    [SerializeField] private GameObject Background;
    [SerializeField] private GameObject Buy;
    [SerializeField] private GameObject Sell;

    public ShopManagerScript shopManagerScript;

    public int planetID;

    public bool justVisited;

    private int oldPlanetID;

    private void Awake() {
        Background.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collider) {
        Background.SetActive(true);
        Buy.SetActive(true);
        Sell.SetActive(true);  
        test();    
    }

    private void OnTriggerExit2D(Collider2D collider) {
        Background.SetActive(false);
        Sell.SetActive(false);
        Buy.SetActive(false);

        justVisited = true;
    }

    public int getPlanetBuyPrice(int itemID) {
            switch (itemID) {
                default:
                    case 1: return Random.Range(4, 10);
                    case 2: return Random.Range(15, 24);
                    case 3: return Random.Range(35, 60);
                    case 4: return Random.Range(55, 75); 
            }
    }

    public int getPlanetSellPrice(int itemID) {
        switch (itemID) {
            default:
                case 1: return Random.Range(1, 14);
                case 2: return Random.Range(4, 35);
                case 3: return Random.Range(9, 85);
                case 4: return Random.Range(14, 115); 
        }
    }      
    
    private void test() {
        //if (justVisited == false){

            shopManagerScript = GameObject.Find("ShopManager").GetComponent<ShopManagerScript>();

            shopManagerScript.shopItems[2,1] = Random.Range(4, 10);
            shopManagerScript.shopItems[2,2] = Random.Range(15, 24);
            shopManagerScript.shopItems[2,3] = Random.Range(35, 60);
            shopManagerScript.shopItems[2,4] = Random.Range(55, 75);

            shopManagerScript.shopItems[4,1] = Random.Range(1, 14);
            shopManagerScript.shopItems[4,2] = Random.Range(4, 35);
            shopManagerScript.shopItems[4,3] = Random.Range(9, 85);
            shopManagerScript.shopItems[4,4] = Random.Range(14, 115);
        //}
    }
}
