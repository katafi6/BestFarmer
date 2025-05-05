using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        _rb.MovePosition(_rb.position + direction * (_moveSpeed * Time.fixedDeltaTime));
    }
}