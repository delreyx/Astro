using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject explosionPrefab;
    public AudioClip explosionSound;
    private AudioSource audioSource;
    private Animator anim;

    private void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (anim != null)
        {
            anim.SetTrigger("takeDamage");
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Explode();
        }
    }

    private void Explode()
    {
        // Instantiate the explosion object at the boss position
        GameObject explosionObject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosionObject, 3f); // Destroy the explosion object after 2 seconds

        // Play the explosion sound
        if (explosionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }

    }
}
