using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowBoss : MonoBehaviour
{
    public string playerTag = "Player";
    private GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    public bool followOnYAxis = true;

    public GameObject explosionPrefab; // Reference to the explosion object

    private bool isDestroyed = false; // Flag to track if the boss is destroyed
    private bool isExploding = false; // Flag to track if the explosion is happening
    private float explosionDuration = 2f; // Duration of the explosion in seconds

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.transform.position;
            if (!followOnYAxis)
            {
                targetPosition.y = transform.position.y;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        if (isDestroyed && !isExploding)
        {
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        isExploding = true;

        // Save the boss position before destroying it
        Vector3 bossPosition = transform.position;

        // Destroy the boss object
        Destroy(gameObject);

        // Instantiate the explosion object at the saved boss position
        GameObject explosionObject = Instantiate(explosionPrefab, bossPosition, Quaternion.identity);
        yield return new WaitForSeconds(explosionDuration);

        // Destroy the explosion object
        Destroy(explosionObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ignore collision with the player object
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision);
        }
    }

    public void DestroyBoss()
    {
        isDestroyed = true;
        if (!isExploding)
        {
            StartCoroutine(Explode());
        }
    }

    private void OnDrawGizmos()
    {
        if (player != null)
        {
            Gizmos.DrawLine(transform.position, player.transform.position);
        }
    }
}
