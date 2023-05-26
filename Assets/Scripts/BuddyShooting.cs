using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyShooting : MonoBehaviour
{
    public GameObject bullet;

    public Transform bulletPos;

    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Get the closes enemy.
        EnemyShooting enemy = EnemyShooting.GetClosest(transform.position);
        
        // if there is no enemy, don't shoot.
        if (enemy == null)
            return;
        
        float distance = Vector2.Distance(transform.position, enemy.transform.position);
        
        if (distance<10)
        {
            timer += Time.deltaTime;
            
            if (timer > 1)
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
