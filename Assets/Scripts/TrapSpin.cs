using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapSpin : MonoBehaviour
{    
    void Update()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            coll.gameObject.GetComponent<PlayerMover>().TakeDamage(3);
        }
    }        
}
