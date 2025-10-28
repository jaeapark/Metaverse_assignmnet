using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] protected SpriteRenderer characterRenderer;
    protected Rigidbody2D rb;
    protected Animator animator;

    [Header("Movement Settings")]
    [SerializeField] protected float moveSpeed = 5f;
    protected Vector2 moveDir = Vector2.zero;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (characterRenderer == null)
            characterRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {
        HandleInput();
        HandleAnimation();
        FlipSprite();
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void HandleInput() { }

    protected void Move()
    {
        rb.velocity = moveDir * moveSpeed;
    }

    protected void FlipSprite()
    {
        if (characterRenderer == null) return;

        if (moveDir.x > 0)
            characterRenderer.flipX = false;
        else if (moveDir.x < 0)
            characterRenderer.flipX = true;
    }

    protected void HandleAnimation()
    {
        if (animator == null) return;
        bool isMoving = moveDir.magnitude > 0;
        animator.SetBool("isMoving", isMoving);
    }
}
