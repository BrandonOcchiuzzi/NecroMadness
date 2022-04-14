using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldGate : MonoBehaviour
{
    //private bool isActive = false;
    public bool hasGoldKey = false;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (hasGoldKey == false)
        {
            GameManager.instance.ShowText("A locked golden gate bars your way.", 25, Color.yellow, this.transform.position, Vector3.up * 25, 2.0f);
        }
       
        else
        {
            GameManager.instance.ShowText("The golden key fits into the lock and with a turn, the gate opens.", 25, Color.yellow, this.transform.position, Vector3.up * 25, 2.0f);
            Destroy(this.gameObject);
        }       
    }    
}
