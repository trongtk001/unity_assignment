using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    Vector3 _lastVelocity;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _lastVelocity = _rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var speed = _lastVelocity.magnitude;
        var direction = Vector3.Reflect(_lastVelocity.normalized, other.contacts[0].normal);
        _rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
