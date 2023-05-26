using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuddy : MonoBehaviour
{
   
    private EnemyShooting enemy;

    private Rigidbody2D rb;

    public float force;

    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = EnemyShooting.GetClosest(transform.position);

        Vector3 direction = enemy.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x)* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<enemyHealth>().TakeDamage(1);
        }
    }
}
