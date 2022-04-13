using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLightning : MonoBehaviour
{
    void Start()
    {
        Invoke("Kill", 5);
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
