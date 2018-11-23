using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleMovement : MonoBehaviour
{
    public float speed = 2f;

    public Vector2 xLimits = new Vector2(-1.25f, 1.25f);
    public Vector2 yLimits = new Vector2(-2.97f, -1.03f);

    private Vector2 movement;

    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(movement * speed * Time.fixedDeltaTime);

        if (transform.position.x < xLimits.x)
        {
            transform.position = new Vector2(xLimits.x, transform.position.y);
        }
        else if (transform.position.x > xLimits.y)
        {
            transform.position = new Vector2(xLimits.y, transform.position.y);
        }

        if (transform.position.y < yLimits.x)
        {
            transform.position = new Vector2(transform.position.x, yLimits.x);
        }
        else if (transform.position.y > yLimits.y)
        {
            transform.position = new Vector2(transform.position.x, yLimits.y);
        }
    }
}
