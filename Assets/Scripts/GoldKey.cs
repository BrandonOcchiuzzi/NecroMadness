using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldKey : MonoBehaviour
{
    public GoldGate goldGate;
    public AudioClip keyPickup;

    private void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("GoldGate");
        goldGate = g.GetComponent<GoldGate>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {      
        AudioSource.PlayClipAtPoint(keyPickup, transform.position, 1);

        GameManager.instance.ShowText("Picked up a Gold Key", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        goldGate.hasGoldKey = true;
        Destroy(this.gameObject);        
    }
}
