using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    public Player player;
    private void OnTriggerEnter2D(Collider2D collider) {
        
        Destroy(this.gameObject);
          
    }
}
