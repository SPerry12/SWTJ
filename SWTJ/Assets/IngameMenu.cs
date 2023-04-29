using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenu : MonoBehaviour
{
    
    public GameObject ingameMenu;

    void Start()
    {
        ingameMenu.SetActive(false);
    }

    public void openMenu() {
        ingameMenu.SetActive(true);
    }

    public void closeMenu() {
        ingameMenu.SetActive(false);
    }
}
