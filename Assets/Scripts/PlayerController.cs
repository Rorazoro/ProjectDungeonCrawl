using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;

    [SerializeField]
    private float _speed = 20.0f;
    [SerializeField]
    private Vector2 _movement;
    [SerializeField]
    private Vector2 _lookDirection = new Vector2(0, 0);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    private void Move()
    {
        if (!Mathf.Approximately(_movement.x, 0.0f) || !Mathf.Approximately(_movement.y, 0.0f))
        {
            _lookDirection.Set(_movement.x, _movement.y);
        }

        _animator.SetFloat("horizontal", _movement.x);
        _animator.SetFloat("vertical", _movement.y);
        _animator.SetFloat("speed", _movement.sqrMagnitude);
        _animator.SetFloat("lookHorizontal", _lookDirection.x);
        _animator.SetFloat("lookVertical", _lookDirection.y);

        _rb.MovePosition(_rb.position + _movement * _speed * Time.deltaTime);
    }
}
