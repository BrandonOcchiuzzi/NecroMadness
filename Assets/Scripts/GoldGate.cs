using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldGate : MonoBehaviour
{
    private bool isActive = false;
    void OnCollisionEnter2D(Collision2D coll)
    {        
        if (isActive == false)
        GameManager.instance.ShowText("A gate with a golden lock bars your way.", 25, Color.yellow, transform.position, Vector3.up * 25, 2.0f);
        isActive = true;               
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        isActive = false;
    }
}
