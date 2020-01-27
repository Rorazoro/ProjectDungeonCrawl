using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private Vector2 movement;
    [SerializeField]
    private int idleDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CalcMovement();
    }

    private void FixedUpdate()
    {
        ExecuteMovement();
    }

    private void CalcMovement()
    {
        //Get movement vector
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //idleDirection = GetIdleDirection();

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
        //animator.SetInteger("idleDirection", idleDirection);
    }

    // private int GetIdleDirection()
    // {
    //     if (movement.x > 0 ) {

    //     }
    // }

    private void ExecuteMovement()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
