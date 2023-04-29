using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int currentHP;

    public bool TakeDamage(int dmg) {
        currentHP -= dmg;

        if(currentHP <= 0)
            return true;
        else    
            return false;
    }
}