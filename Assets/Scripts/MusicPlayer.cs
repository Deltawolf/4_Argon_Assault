using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
            Destroy(this.gameObject);
        else
        {
          
            DontDestroyOnLoad(this.gameObject);
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
