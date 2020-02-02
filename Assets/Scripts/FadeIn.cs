using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
        Image image;
        SceneCoordinator sceneCoordinator;
        Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        sceneCoordinator = FindObjectOfType<SceneCoordinator>();
        if (!sceneCoordinator.isGameStart)
        {
            //Would be nice if this set the ALPHA to 0
            animator.SetBool("Start", false);
            image.color = new Color(255f, 255f, 255f, 0f);
        }
        else
            animator.SetBool("Start", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
