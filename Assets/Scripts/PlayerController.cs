using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    //todo Slow start on play

    //X is Pitch, Rotate X second
    //Y is Yaw, Rotate Y first
    //Z is Roll
    [Header("General Parameters")]
    [Tooltip("In ms^-1")]
    [SerializeField]
    float xSpeed = 4.5f;
    [SerializeField]
    float xDistance = 5f;
    [Tooltip("In ms^-1")]
    [SerializeField]
    float ySpeed = 4.5f;
    [SerializeField]
    float yDistance = 3f;

    [Header("Screen-Based Parameters")]
    [SerializeField]
    float pitchFactor = -5f;
    [SerializeField]
    float yawFactor = 8f;

    [Header("Control-Throw Based Parameters")]
    [SerializeField]
    float pitchControlFactor = -20f;
    [SerializeField]
    float yawControlFactor = 20f;
    [SerializeField]
    float rollControlFactor = -40f;

    float xThrow;
    float yThrow;
    bool isControlEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            Translation();
            Rotation();
        }
    }

    

    void Translation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        //Create frame independence and movement speed
        float xOffset = xThrow * Time.deltaTime * xSpeed;
        float yOffset = yThrow * Time.deltaTime * ySpeed;

        //Move the ship by adding to our current position relative to the camera
        float rawXpos = transform.localPosition.x + xOffset;
        float rawYpos = transform.localPosition.y + yOffset;

        //Create boundaries for the ship to stay on the screen
        float clampedXpos = Mathf.Clamp(rawXpos, -xDistance, xDistance);
        float clampedYpos = Mathf.Clamp(rawYpos, -yDistance+.4f, yDistance + .4f);

        //Set transform
        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }

    void Rotation()
    {
        float roll = 0f;
        //Move the nose of our ship further as we get to the edge of the screen
        //Add additional control once we reach the boundary to still control the nose
        float pitch = transform.localPosition.y * pitchFactor + yThrow * pitchControlFactor;
        float yaw = transform.localPosition.x * yawFactor + xThrow * yawControlFactor;
        
        if (Input.GetAxis("BankL") > .1f)
            roll = Input.GetAxis("BankL")*.85f*90f; //turning left and right rolls the ship slightly
        else if (Input.GetAxis("BankR") > .1f)
            roll = Input.GetAxis("BankR") * .85f*-90f; //turning left and right rolls the ship slightly
        else
            roll = xThrow * rollControlFactor; //turning left and right rolls the ship slightly


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        
    }

    void ControlSet(bool controlSet) //string referenced
    {
        isControlEnabled = controlSet;
    }

}



/*
        float pitch = Mathf.Clamp(transform.localPosition.y * pitchFactor+yThrow*pitchControlFactor,-20f,20f);
        float yaw = Mathf.Clamp(transform.localPosition.x * yawFactor+xThrow*yawControlFactor, -20f, 20f);
        */
