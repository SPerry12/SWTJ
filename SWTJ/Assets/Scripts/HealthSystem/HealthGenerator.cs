using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGenerator : MonoBehaviour
{
    public GameObject healthPrefab;
    void Start()
    {
        GenerateHealth();
    }

    void GenerateHealth() {
        StartCoroutine(GenerateHealthRoutine());
        
        IEnumerator GenerateHealthRoutine() {
            while(true) {
                Vector2 randomPosition = new Vector2(Random.Range(-21f, 21f), Random.Range(-8f, 11f));
                yield return new WaitForSeconds(15f);
                GameObject newHealth = Instantiate(healthPrefab, randomPosition,Quaternion.identity);
                Destroy(newHealth, 30);
            }
        }
    }
}
