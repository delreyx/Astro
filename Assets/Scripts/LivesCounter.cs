using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public GameObject[] hearts;
    public int life ;

    public GameManagerScript gameManager;

    private bool isDead;

    // Update is called once per frame
    void Start()
    {
        life = hearts.Length;
    }

    public void TakeDamage(int d)
    {
        life = Mathf.Clamp(life - d, 0, 4);
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
        if (collision.tag == "Life")
        {
            AddLives(1);
            Destroy(collision.gameObject);
        }
    
    }
void Update() {


    if (life <=0 && !isDead)
    {
        isDead = true;
        gameManager.gameOver();
    }

}

   
}
