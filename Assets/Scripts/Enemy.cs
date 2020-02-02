using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int remainingHits = 4;

    Scoreboard[] scoreBoard;
    bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectsOfType<Scoreboard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        remainingHits--;

        if (remainingHits <= 0)
        {
            for (int i = 0; i < scoreBoard.Length; i++)
            {
                scoreBoard[i].ScoreHit(10);

            }


            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
            Destroy(gameObject);
        }
        
    }
}
