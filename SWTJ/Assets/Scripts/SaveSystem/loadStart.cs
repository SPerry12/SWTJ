using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadStart : MonoBehaviour
{
    public SaveLoad saveLoad;
    // Start is called before the first frame update
    void Awake()
    {
        saveLoad.Load();
    }

   
}
