using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public AudioClip bulletSound;

    private float timer;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bulletSound;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the closest enemy.
        EnemyShooting enemy = EnemyShooting.GetClosest(transform.position);

        // If there is no enemy, don't shoot.
        if (enemy == null)
            return;

        float distance = Vector2.Distance(transform.position, enemy.transform.position);

        if (distance < 10)
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                timer = 0;
                shoot();
                audioSource.PlayOneShot(bulletSound); // Play the bullet sound
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}