using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // all enemies know who the player is
    private static GameObject player;

    // a list of all active enemies
    private static List<EnemyShooting> enemies = new List<EnemyShooting>();
    
    public GameObject bullet;

    public Transform bulletPos;

    private float timer;

    public static EnemyShooting GetClosest(Vector3 point)
    {
        float distance = 1000f;
        EnemyShooting closestEnemy = null;
        
        foreach (EnemyShooting enemyShooting in enemies)
        {
            float d = Vector3.Distance(enemyShooting.transform.position, point);
            if (d < distance)
            {
                distance = d;
                closestEnemy = enemyShooting;
            }
        }

        return closestEnemy;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        
        enemies.Add(this);
    }

    private void OnDestroy()
    {
        enemies.Remove(this);
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance<10)
        {
            timer += Time.deltaTime;
            
            if (timer > 2)
            {
                timer = 0;
                shoot();
            }

        }


        void shoot()
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
}
}
