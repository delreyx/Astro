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
    private AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = EnemyShooting.GetClosest(transform.position);

        Vector3 direction = enemy.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private bool hasAppliedDamage = false; // New variable to track if damage has been applied

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasAppliedDamage) return; // If damage has already been applied, exit the method

        if (other.CompareTag("Enemy"))
        {
            enemyHealth enemyHealthComponent = other.GetComponent<enemyHealth>();
            bossHealth bossHealthComponent = other.GetComponent<bossHealth>();

            if (enemyHealthComponent != null)
            {
                enemyHealthComponent.TakeDamage(1);
            }

            if (bossHealthComponent != null)
            {
                bossHealthComponent.TakeDamage(1);
            }

            hasAppliedDamage = true; // Set the flag to indicate that damage has been applied
        }
    }

    }
