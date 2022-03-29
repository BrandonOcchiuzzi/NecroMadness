using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    private Spawner spawnScript;
    
     void Awake()
    {
        spawnScript = GetComponent<Spawner>();
        spawnScript.enabled = false;
                
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            spawnScript.enabled = true;
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") spawnScript.enabled = false;   
    }

}
