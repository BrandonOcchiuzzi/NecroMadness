using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public GameObject lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void Start()
    {       
        lookAt = GameObject.FindGameObjectWithTag("Player");       
    }   

    //LateUpdate is being called after Update and after FixedUpdate
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // This is to check if we're inside the bounds on the X Axis
        float deltaX = lookAt.transform.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.transform.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }

        }

        // This is to check if we're inside the bounds on the Y Axis
        float deltaY = lookAt.transform.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.transform.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
