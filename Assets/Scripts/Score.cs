using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public int score = 0;

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    void Update()
    {

    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "KillBox")
        {
            score--;
            scoreText.text = "Score: " + score.ToString();            
        }
    }
}