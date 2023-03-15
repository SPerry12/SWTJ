using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionDirect : MonoBehaviour
{
    private Vector3 movePosition;

    public void SetMovePosition(Vector3 movePosition) {
        this.movePosition = movePosition;
    }
    void Update() {
        
        Vector3 moveDir;

        if (Vector3.Distance(movePosition, transform.position) < .0001f){
            moveDir = Vector3.zero;
        } 
        else {
            moveDir = (movePosition - transform.position).normalized;
        }

        GetComponent<IMoveVelocity>().SetVelocity(moveDir);
    }
}
