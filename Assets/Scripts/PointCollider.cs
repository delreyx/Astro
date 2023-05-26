using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollider : MonoBehaviour
{
     private float lastYPos = 0;

     private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            if (lastYPos > other.transform.position.y) return;
            if (transform.position.y > other.transform.position.y) return;

            Score scoreCounter = GameObject.FindObjectOfType<Score>();
            if(scoreCounter != null)
            {
                scoreCounter.IncrementScore();
                lastYPos = other.transform.position.y + 0.5f;
            }
        }
    }
}
