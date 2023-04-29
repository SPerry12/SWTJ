using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class AIMovement : MonoBehaviour, IPoolObject 
{
    public float speed = 1f;

    Rigidbody2D rb;

    public Player player;
    
    IEnumerator DoMovement(){
        Vector2 direction = Random.insideUnitCircle;
        for(;;){
            rb.MovePosition(transform.position + (Vector3)direction * speed);
            yield return new WaitForSeconds(3f);

            direction = Random.insideUnitCircle;
            rb.MovePosition(transform.position + (Vector3)direction * speed);
        
        }
    }

    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("DoMovement");
    }


    private void OnTriggerEnter2D(Collider2D collider) {


        if(collider.gameObject.tag.Equals("Player") == true) {
            SceneManager.LoadScene("SpaceWar");
            gameObject.SetActive(false);
        }

        if(collider.gameObject.tag.Equals("Col") == true) {
            gameObject.SetActive(false);
        }
           
    }
}
