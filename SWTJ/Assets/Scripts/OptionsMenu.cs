using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public void OpenMenu() {
        GetComponent<Canvas>().enabled = true;
    }

    public void Close() {
        GetComponent<Canvas>().enabled = false;
    }
}
