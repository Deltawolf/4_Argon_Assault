using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    //X is Pitch, Rotate X second
    //Y is Yaw, Rotate Y first
    //Z is Roll
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
    [SerializeField]
    float pitchFactor = -5f;
    [SerializeField]
    float yawFactor = 8f;
    [SerializeField]
    float pitchControlFactor = -20f;
    [SerializeField]
    float yawControlFactor = 20f;
    [SerializeField]
    float rollControlFactor = -40f;

    float xThrow;
    float yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Translation();
        Rotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Woah nelly!");
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
        
        //Move the nose of our ship further as we get to the edge of the screen
        //Add additional control once we reach the boundary to still control the nose
        float pitch = transform.localPosition.y * pitchFactor + yThrow * pitchControlFactor;
        float yaw = transform.localPosition.x * yawFactor + xThrow * yawControlFactor;
        float roll = xThrow * rollControlFactor; //turning left and right rolls the ship slightly
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        
    }

    }



/*
        float pitch = Mathf.Clamp(transform.localPosition.y * pitchFactor+yThrow*pitchControlFactor,-20f,20f);
        float yaw = Mathf.Clamp(transform.localPosition.x * yawFactor+xThrow*yawControlFactor, -20f, 20f);
        */
