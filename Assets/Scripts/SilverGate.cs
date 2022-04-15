using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilverGate : MonoBehaviour
{
    public bool hasSilverKey;
    public AudioClip gateOpen;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (hasSilverKey == false)
        {
            GameManager.instance.ShowText("A locked silver gate bars your way.", 25, Color.yellow, this.transform.position, Vector3.up * 25, 2.0f);
        }

        if (hasSilverKey == true)
        {
            GameManager.instance.ShowText("With a turn the silver key opens the gate.", 25, Color.yellow, this.transform.position, Vector3.up * 25, 3.0f);
            StartCoroutine("GateOpenDelay");
        }
    }

    IEnumerator GateOpenDelay()
    {
        AudioSource.PlayClipAtPoint(gateOpen, transform.position, 1);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}