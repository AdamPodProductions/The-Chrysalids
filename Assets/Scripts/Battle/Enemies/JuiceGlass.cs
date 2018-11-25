using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceGlass : MonoBehaviour
{
    public Bullet juice;
    public BoxCollider2D boxCollider;

    public Transform player;

    private bool following = true;

    private void Start()
    {
        player = FindObjectOfType<PlayerBattleMovement>().transform;
    }

    private void Update()
    {
        if (following)
        {
            transform.position = new Vector2(player.position.x, transform.position.y);
        }
    }

    public void Spill()
    {
        juice.enabled = true;
        boxCollider.enabled = true;
    }

    public void StopFollowing()
    {
        following = false;
    }
}
