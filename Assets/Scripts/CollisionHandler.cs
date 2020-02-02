using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 5f;
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hull;
    SceneCoordinator sceneCoordinator;
    BetterWaypointFollower waypoint;

    // Start is called before the first frame update
    void Start()
    {
        sceneCoordinator = FindObjectOfType<SceneCoordinator>();
        waypoint = GetComponentInParent<BetterWaypointFollower>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        
    }

   

    private void StartDeathSequence()
    {
        deathFX.SetActive(true);
        Destroy(hull);
        waypoint.SetRouteSpeed(0.1f);
        SendMessage("ControlSet", false);

        Invoke("LoadStart", levelLoadDelay);
        
    }

    void LoadStart() //string reference
    {
        sceneCoordinator.Restart();
    }


    /*
     * 
     * [SerializeField]
    ParticleSystem explode;
    [SerializeField]
    ParticleSystem Flare;
    [SerializeField]
    ParticleSystem Smoke;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip myClip;
*  explode.Play();
   Flare.Play();
   Smoke.Play();
   audioSource.PlayOneShot(myClip);
*/
}


