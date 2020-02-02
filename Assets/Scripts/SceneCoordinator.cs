using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCoordinator : MonoBehaviour
{
    public bool isGameStart = true;
    private void Awake()
    {
        int sceneCoords = FindObjectsOfType<SceneCoordinator>().Length;
        if (sceneCoords > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {

            DontDestroyOnLoad(this.gameObject);
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
            LoadSplash(22.1f);
    }
    
    void LoadSplash(float loadTime)
    {
            SceneManager.LoadScene(1);
            Invoke("LoadLevel", loadTime);
    }
  
    void LoadLevel() //string referenced
    {
        SceneManager.LoadScene(2);
        isGameStart = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
    }
}
