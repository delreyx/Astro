using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public GameObject[] hearts;
    public int life ;

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void TakeDamage(int d)
    {
        life -= d;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Asteroid" && life <1)
        {
            Destroy(hearts[0].gameObject);
            
        }else if (collision.tag == "Asteroid" && life <2)
        {
            Destroy(hearts[1].gameObject);

        }else if (collision.tag == "Asteroid" && life <3)
        {
            Destroy(hearts[2].gameObject);
        }
    
    }

   
}
