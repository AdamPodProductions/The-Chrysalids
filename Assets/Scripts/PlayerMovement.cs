using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 movement;
    private bool isMoving;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        isMoving = movement != Vector2.zero;

        transform.Translate(movement * speed * Time.fixedDeltaTime);

        animator.SetBool("isMoving", isMoving);
        animator.SetFloat("xMove", movement.x);
        animator.SetFloat("yMove", movement.y);
    }
}
