using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private TrailRenderer _trailRenderer;
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

    [Header("Dashing")]
    [SerializeField] private float _dashingVelocity = 14f;
    [SerializeField] private float _dashingTime = 0.5f;
    private Vector2 _dashingDir;
    private bool _isDashing;
    private bool _canDash = true;

    private AudioSource audioSource;

    private Animator playerAnimation;

    


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(0.315f, 0.2633438f);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-0.315f, 0.2633438f);
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

        var dashInput = Input.GetButtonDown("Fire3");
        if (direction != 0 && dashInput && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            _trailRenderer.emitting = true;
            _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            if (_dashingDir == Vector2.zero)
            {
                _dashingDir = new Vector2(transform.localScale.x, 0);
            }

            StartCoroutine(StopDashing());

        }

        // _animator.SetBool("IsDashing", _isDashing);
        if (_isDashing)
        {
            player.velocity = _dashingDir.normalized *_dashingVelocity;
            return;
        }

        if (isTouchingGround)
        {
            _canDash = true;
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);

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
        if (collision.tag == "Asteroid")
        {
            audioSource.PlayOneShot(collisionClip);
        }
        
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashingTime);
        _trailRenderer.emitting = false;
        _isDashing = false;
    }

   
}