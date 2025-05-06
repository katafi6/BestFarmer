using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _movement;
    private FarmPlayerInput _input;
    private Animator _animator;


    private Vector2 _moveDir = Vector2.zero;
    private Vector2 _lastDir = Vector2.zero;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        _input = new FarmPlayerInput();
        _input.Enable();
    }


    // Update is called once per frame
    void Update()
    {
        _moveDir = _input.Player.Move.ReadValue<Vector2>();
        bool isMove = false;
        if (_moveDir != Vector2.zero)
        {
            _lastDir = _moveDir;
            isMove = true;
        }

        _animator.SetBool("IsMove", isMove);
        _animator.SetFloat("InputDirX", _lastDir.x);
        _animator.SetFloat("InputDirY", _lastDir.y);
    }

    private void FixedUpdate()
    {
        _movement.Move(_moveDir);
    }

   
}