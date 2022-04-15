using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToVillage : MonoBehaviour
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
            coll.transform.position = new Vector3(2.55f, -4.3f, 0);
            music.PlayVillage();
        }

    }
}
