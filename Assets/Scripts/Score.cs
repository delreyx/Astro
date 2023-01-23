using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public static int score = 0;

    public TextMeshProUGUI scoreText;

    private Animator backgroundAnimation;
    private float cycleOffset;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        backgroundAnimation = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        backgroundAnimation.SetFloat("Transition", ((float)score)/400f);

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