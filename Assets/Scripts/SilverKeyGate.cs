using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilverGate : MonoBehaviour
{
    //private bool isActive = false;
    public bool hasSilverKey = false;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (hasSilverKey == false)
        {
            GameManager.instance.ShowText("A locked silver gate bars your way.", 25, Color.yellow, this.transform.position, Vector3.up * 25, 2.0f);
        }

        else
        {
            GameManager.instance.ShowText("The silver key fits into the lock and with a turn, the gate opens.", 25, Color.yellow, this.transform.position, Vector3.up * 25, 2.0f);
            Destroy(this.gameObject);
        }
    }
}
