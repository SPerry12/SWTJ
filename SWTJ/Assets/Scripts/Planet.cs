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

    public int oldPlanetID = 0;

    private void Awake() {
        Background.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collider) {
        Background.SetActive(true);
        Buy.SetActive(true);
        Sell.SetActive(true);
        Debug.Log("This is planet id: " + planetID);
        test();    
        oldPlanetID = planetID;  
    }

    private void OnTriggerExit2D(Collider2D collider) {
        Background.SetActive(false);
        Sell.SetActive(false);
        Buy.SetActive(false);
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
    
    private void test() {
        if (oldPlanetID != planetID){
            Debug.Log("Old planet id is not equal to planetID");

            shopManagerScript = GameObject.Find("ShopManager").GetComponent<ShopManagerScript>();

            shopManagerScript.shopItems[2,1] = Random.Range(4, 10);
            shopManagerScript.shopItems[2,2] = Random.Range(15, 24);
            shopManagerScript.shopItems[2,3] = Random.Range(35, 60);
            shopManagerScript.shopItems[2,4] = Random.Range(55, 75);

            //oldPlanetID = planetID;
            Debug.Log("This is old planet after test: " + oldPlanetID);
        }

    }
}
