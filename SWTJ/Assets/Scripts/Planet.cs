using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collider) {
        Debug.Log("Trigger!");
    }
}
