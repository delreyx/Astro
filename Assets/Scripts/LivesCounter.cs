using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public GameObject[] hearts;
    public int life ;

    // Update is called once per frame
    void Start()
    {
        life = hearts.Length;
    }

    public void TakeDamage(int d)
    {
        life -= d;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i < life);
        }
    }

    public void AddLives(int d)
        => TakeDamage(-d);

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Asteroid")
        {
            TakeDamage(1);
        }
    
    }

   
}
