using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToCatacomb : MonoBehaviour
{
    public BackgroundMusic music;

    void Start()
    {
        music = GameObject.Find("BackgroundMusic").GetComponent<BackgroundMusic>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Player")
        {            
            coll.transform.position = new Vector3(35, 18.5f, 0);
            music.PlayCatacombs();
        }

    }
}
