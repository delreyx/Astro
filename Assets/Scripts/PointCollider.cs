using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollider : MonoBehaviour
{
     private static float lastYPos = 0;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            if (lastYPos > other.transform.position.y) return;

            Score scoreCounter = GameObject.FindObjectOfType<Score>();
            if(scoreCounter != null)
            {
                scoreCounter.IncrementScore();
                lastYPos = other.transform.position.y;
            }
        }
    }
}
