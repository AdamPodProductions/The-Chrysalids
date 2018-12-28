using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public float speed = 5f;
    public bool canMove = true;

    private Vector2 movement;
    private bool isMoving;

    private Animator animator;

    private void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canMove)
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            isMoving = movement != Vector2.zero;

            transform.Translate(movement * speed * Time.fixedDeltaTime);

            animator.SetBool("isMoving", isMoving);
            animator.SetFloat("xMove", movement.x);
            animator.SetFloat("yMove", movement.y);
        }
    }

    public void PlayerCanMove()
    {
        canMove = true;
    }
}
