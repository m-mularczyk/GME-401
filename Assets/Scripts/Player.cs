using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private PlayerAnimation _playerAnimation;
    private SpriteRenderer _playerSpriteRenderer;

    private Rigidbody2D _rb;
    private bool _resetJump;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {

        Movement();

        if (Input.GetMouseButtonDown(0) && _isGrounded)
        {
            _playerAnimation.Attack();
        }

    }

    /*
    private void CheckGrounded()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);

        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);
            _isGrounded = true;
        }
    }
    */

    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");

        _isGrounded = IsGrounded();

        if (move > 0)
        {
            Flip(false);
        }
        else if (move < 0)
        {
            Flip(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            // Jump
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _playerAnimation.Jump(true);
            StartCoroutine(ResetJumpRoutine());
            //Debug.Log("Jump Animation Started");
        }

        _rb.velocity = new Vector2(move * _speed, _rb.velocity.y);

        _playerAnimation.Move(move);
        
    }

    private void Flip(bool value)
    {
        _playerSpriteRenderer.flipX = value;
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.red);

        if (hit.collider != null)
        {
            if(_resetJump == false)
            {
                //Debug.Log("Grounded");
                _playerAnimation.Jump(false);
                return true;
            }
            
        }
        
        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
