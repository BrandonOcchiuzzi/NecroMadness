using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToVillage : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            coll.transform.position = new Vector3(2.55f, -4.3f, 0);
        }

    }
}
