using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : Collectable
{    
    public bool hasSilverKey;
    public bool hasGoldKey;
    
    void Awake()
    {
        hasSilverKey = false;
        hasGoldKey = false;
    }

    protected override void OnCollect()
    {
        if (collected == true)
        {
            hasGoldKey = true;
            GameManager.instance.ShowText("Picked up a Gold Key", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }

        if (collected == true)
        {
            hasSilverKey = true;
            GameManager.instance.ShowText("Picked up a Silver Key", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);

        }
    }
    
}
