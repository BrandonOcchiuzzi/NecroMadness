using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldGate : MonoBehaviour
{    
    public bool hasGoldKey;
    public FloatTextManager floatTextManager;

    private void Start()
    {
        floatTextManager = GameObject.Find("FloatTextManager").GetComponent<FloatTextManager>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (hasGoldKey == false)
        {
            floatTextManager.Show("A locked golden gate bars your way.", 25, Color.yellow, this.transform.position, Vector3.up * 25, 2.0f);
        }

        if (hasGoldKey == true)
        {
            floatTextManager.Show("With a turn the golden key opens the gate.", 25, Color.yellow, this.transform.position, Vector3.up * 25, 3.0f);
            StartCoroutine("GateOpenDelay");
        }       
    }    

    IEnumerator GateOpenDelay()
    {        
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);          
    }
}
