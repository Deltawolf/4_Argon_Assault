using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{


    public Transform crosshair;
    public Camera cam;
    public Transform nose;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(nose.transform.position, nose.transform.forward, out hit))
        {
            if (hit.collider)
            {
                crosshair.position = cam.WorldToScreenPoint(hit.point);
            }
        }


    }
}
