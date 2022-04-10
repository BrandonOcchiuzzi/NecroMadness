using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject player;
    public float distance;
    
    
    // Update is called once per frame
    void Update()
    {
        //measures the distance of the player to each crystal via the tag and activates
        //the spawn script if that distance is less than the set number of units.
        Transform playerTransform = GameObject.FindWithTag("Player").transform;
        distance = Vector3.Distance(playerTransform.transform.position, this.transform.position);
        if (distance < 2)
        {
            GetComponent<Spawner>().enabled = true;
        }
        else
        {
            GetComponent<Spawner>().enabled = false;
        }
    }
    /*
    //References
    public Spawner spawnScript;
    public Transform playerTransform;
    public Transform crystalTransform;

    //Logic
    float triggerDistance = Vector3.Distance (playerTransform.transform.position, crystalTransform.transform.position);

    void Awake()
    {                    
        spawnScript = GetComponent<Spawner>();
        spawnScript.enabled = false;                
        playerTransform = GameManager.instance.player.transform;
        crystalTransform = SummoningCrystals.transform.position;
    }
    private void Start()
    {
    }

    private void Update()
    {
        
    }

    private void CheckPlayerDistance()
    {
        if (triggerDistance < 2)
            spawnScript.enabled = true;
           
        else        
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
    */
}
