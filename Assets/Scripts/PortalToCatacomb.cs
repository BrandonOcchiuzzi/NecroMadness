using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToCatacomb : Collidable
{
    //public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {            
            coll.transform.position = new Vector3(35, 18.5f, 0);
        }

    }
}
