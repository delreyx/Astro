using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public GameObject explosionPrefab; // Reference to the explosion object
    public AudioClip explosionSound; // Reference to the explosion sound

    private AudioSource audioSource; // Reference to the AudioSource component
    private Animator anim;

    private void Start()
    {
        currentHealth = maxHealth;

        // Create an AudioSource component if it doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the explosion sound to the AudioSource component
        audioSource.clip = explosionSound;

        // Get the Animator component attached to the boss object
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
            currentHealth = 0; // Ensure health doesn't go below 0
            Explode();
            Destroy(gameObject);
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