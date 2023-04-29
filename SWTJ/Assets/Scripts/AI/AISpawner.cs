using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start() {
        objectPooler = ObjectPooler.Instance;
        StartCoroutine("DoSpawn");
    }

    IEnumerator DoSpawn(){
            for(;;) {
                objectPooler.SpawnFromPool("AI", transform.position + new Vector3(Random.Range(-21,20), Random.Range(-8,11),0), Quaternion.identity);
                yield return new WaitForSeconds(10f);
            }
            

    }

}
