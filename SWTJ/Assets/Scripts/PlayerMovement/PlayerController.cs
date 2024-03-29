using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Tilemap spaceTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    public GameObject eventCanvas;
    private PlayerMovement controls;

    public ShopManagerScript shopManagerScript;
    public Player player;

    public Events events;

    
    
    private void Awake() {
        controls = new PlayerMovement();
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

    void Start()
    {
        // Subscribing to the event (pressing down)
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction) {

        if (CanMove(direction)) {
            transform.position += (Vector3)direction;

            shopManagerScript = GameObject.Find("ShopManager").GetComponent<ShopManagerScript>();

            shopManagerScript.shopItems[3,1]--;
            player.fuelAmount = shopManagerScript.shopItems[3,1];
            player.setFuelTxt();
            

            if(shopManagerScript.shopItems[3,1] <= 0) {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public bool CanMove(Vector2 direction) {
        Vector3Int gridPosition = spaceTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!spaceTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition) || eventCanvas.activeSelf)
            return false;
        return true;
    }
}
