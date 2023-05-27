using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Animator _animator;
    private float _horizontalInput;
    private float _xConstraint = 9.4f, _yConstraint = 4.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); 
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        if ((_horizontalInput > 0 && transform.position.x >= _xConstraint) || (_horizontalInput < 0 && transform.position.x <= -_xConstraint))
            _horizontalInput = 0;

        if ((verticalInput > 0 && transform.position.y >= _yConstraint) || (verticalInput < 0 && transform.position.y <= -_yConstraint))
            verticalInput = 0;

        Vector2 movement = new Vector2(_horizontalInput, verticalInput) * moveSpeed;

        _rb.velocity = movement;

        UpdateAnimation();
    }
    
    private void UpdateAnimation()
    {
        if (_horizontalInput > 0)
        {
            _animator.Play("swim_to_right");
        }
        else if (_horizontalInput < 0)
        {
            _animator.Play("swim_to_left");
        }
        else
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("swim_to_right"))
            {
                _animator.Play("rest_to_right");
            }
            else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("swim_to_left"))
            {
                _animator.Play("rest_to_left");
            }
        }
    }
}
