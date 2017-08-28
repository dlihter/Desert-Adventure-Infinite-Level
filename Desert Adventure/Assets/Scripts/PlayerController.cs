using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public bool IsGrounded = true;
    public Transform GroundCheck;
    public float Jumpforce = 5.0f;
    private Rigidbody2D _rb;
    private bool _isFacingRight = true;
    private bool _isWalking;
    private Animator _animator;
    private bool _doubleJump = false;
    private Vector3 startingPoint;

    public AudioClip DeathSFX;
    public GameObject DeathParticlesPrefab;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        startingPoint = transform.position;
    }

    private void Update()
    {
        float _horizontalMovement = Input.GetAxisRaw("Horizontal");
        float _verticalMovement = _rb.velocity.y;
        Movement(_horizontalMovement,_verticalMovement);
        Flipping(_horizontalMovement);
    }

    void Movement(float horizontal,float vertical)
    {
        Debug.DrawLine(transform.position, GroundCheck.position,Color.white);
        IsGrounded = Physics2D.Linecast(transform.position,GroundCheck.position,1<<LayerMask.NameToLayer("Ground"));
        //Reset double jump
        if (IsGrounded)
        {
            _doubleJump = false;
        }

        if ((IsGrounded || !_doubleJump)&&Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector2.up*Jumpforce);
            if(!_doubleJump && !IsGrounded)
            {
                _doubleJump = true;
            }
        }
        if (Input.GetButtonUp("Jump") && vertical > 0.0f)
        {
            vertical = 0.0f;
        }
        _animator.SetBool("IsGrounded", IsGrounded);
        if(horizontal!=0)
        {
            _isWalking = true;
        }
        else
        {
            _isWalking = false;
        }
        _animator.SetBool("IsWalking", _isWalking);
        _rb.velocity = new Vector2(horizontal * MovementSpeed, vertical);
    }
    void Flipping(float horizontal)
    {
        Vector3 localscale = transform.localScale;
        if (horizontal > 0.0f)
        {
            _isFacingRight = true;
        }
        else if (horizontal < 0.0f)
        {
            _isFacingRight = false;
        }
        if (_isFacingRight && (localscale.x < 0.0f) || !_isFacingRight && (localscale.x > 0.0f))
        {
            localscale.x *= -1.0f;
        }
        transform.localScale = localscale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadZone"))
        {
            if (DeathSFX)
            {
                AudioSource.PlayClipAtPoint(DeathSFX, transform.position);
            }

            if (DeathParticlesPrefab)
            {
                Instantiate(DeathParticlesPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
