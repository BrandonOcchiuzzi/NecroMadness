using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNecro : MonoBehaviour
{
    Camera mainCamera;
    public Camera cameraTwo;

    public NecromancerFlyAway necro;

    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.enabled = true;
        cameraTwo.enabled = false;
        necro = GameObject.Find("NecromancerTrigger").GetComponent<NecromancerFlyAway>();
    }
    private void Update()
    {
        if (necro.isTriggered == false)
        {
            mainCamera.enabled = true;
            cameraTwo.enabled = false;
        }
        else if (necro.isTriggered == true)
        {
            cameraTwo.enabled = true;
            mainCamera.enabled = false;
        }
    }
}
