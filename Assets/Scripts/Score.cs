using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private float score;
    [SerializeField] public GameObject player;

    float lastYposition= -100;
    float currentYposition;

    void Update(){
        currentYposition = player.transform.position.y;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Platform")
        {
            if(currentYposition > lastYposition)
            {
                lastYposition = currentYposition;
                score++;
            }
            // is my position on Y > lastYposition?
            // if yes, lastYposition = current Y position
            // add a point
        }
    }
}