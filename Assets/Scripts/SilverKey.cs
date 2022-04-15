using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilverKey : MonoBehaviour
{
    public SilverGate silverGate;
    public AudioClip keyPickup;
    public FloatTextManager floatTextManager;

    private void Start()
    {
        floatTextManager = GameObject.Find("FloatTextManager").GetComponent<FloatTextManager>();
        GameObject h = GameObject.FindGameObjectWithTag("SilverGate");
        silverGate = h.GetComponent<SilverGate>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource.PlayClipAtPoint(keyPickup, transform.position, 1);

        floatTextManager.Show("Picked up a silver Key", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        silverGate.hasSilverKey = true;
        Destroy(this.gameObject);
    }
}
