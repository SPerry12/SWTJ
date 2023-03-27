using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Planet : MonoBehaviour {

    [SerializeField] private GameObject Background;
    [SerializeField] private GameObject Buy;
    [SerializeField] private GameObject Sell;
        private void Awake() {
                Background.SetActive(false);
        }
    
    private void OnTriggerEnter2D(Collider2D collider) {
            Background.SetActive(true);
            Buy.SetActive(true);
            Sell.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collider) {
            Background.SetActive(false);
            Sell.SetActive(false);
            Buy.SetActive(false);
    }

   /* public void SetSell() {
        Sell.SetActive(true);
        Debug.Log("I was clicked");
    }

    public void SetBuy() {
        Buy.SetActive(true);
        Debug.Log("I was clicked");
    } */
}
