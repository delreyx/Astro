using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
   private float minPush = 5;
   private float maxPush = 10;
   private Rigidbody2D asteroid;
  

    // Start is called before the first frame update
    void Start()
    {
        asteroid = GetComponent<Rigidbody2D>();
        asteroid.velocity = Vector2.down * Random.Range(minPush, maxPush);
    }

  
}
