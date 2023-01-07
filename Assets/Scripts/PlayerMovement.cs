using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    public Vector3 respawnPoint;
    public GameObject killBox;
    private bool doubleJump;

    [Header("Audio")]
    public AudioClip collisionClip;
    public AudioClip jumpClip;

    private AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
             
        }

        killBox.transform.position = new Vector2(transform.position.x, killBox.transform.position.y);

    }

    void onJump() {
        
        audioSource.PlayOneShot(jumpClip);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "KillBox")
        {
            transform.position = respawnPoint;
            
        }
        if(collision.tag == "Asteroid")
        {
            transform.position = respawnPoint;
        }
    
    }

   
}

