using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject lightning;
    //public AudioClip thunder;

    private void Update()
    {
        int random = Random.Range(0, 1000);
        Vector3 position = new Vector3(Random.Range(-1.7f, 1.7f), Random.Range(-0.8f, 0.5f), 0);
        if (random == 15)
        {
            Instantiate(lightning, position, Quaternion.identity);
            //AudioSource.PlayClipAtPoint(thunder, transform.position, 1);
        }
        
    }
}
