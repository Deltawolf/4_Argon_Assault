using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] int scorePerHit = 10;
    int score;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        ScoreHit(0);
    }


    public void ScoreHit(int score)
    {
       
        this.score += score;
        scoreText.text = "Score: " + score.ToString();
    }

}
