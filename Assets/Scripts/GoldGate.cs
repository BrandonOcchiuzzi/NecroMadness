using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldGate : MonoBehaviour
{    
    public bool hasGoldKey;
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (hasGoldKey == false)
        {
            GameManager.instance.ShowText("A locked golden gate bars your way.", 25, Color.yellow, this.transform.position, Vector3.up * 25, 2.0f);
        }

        if (hasGoldKey == true)
        {
            GameManager.instance.ShowText("With a turn the golden key opens the gate.", 25, Color.yellow, this.transform.position, Vector3.up * 25, 3.0f);
            StartCoroutine("GateOpenDelay");
        }       
    }    

    IEnumerator GateOpenDelay()
    {        
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);          
    }
}
