using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBar : MonoBehaviour
{
    public float speed = 8f;

    public GameObject damageAnim;

    public Animator animator;

    private int direction = 1;
    private bool moving = true;

    private void Update()
    {
        if (moving)
        {
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

            if (transform.position.x > 3.88f)
            {
                direction = -1;
            }
            else if (transform.position.x < -3.88f)
            {
                direction = 1;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ToggleMovement(false);
                BattleManager.instance.playerDamage.damage = GetDamageFromPosition();

                animator.SetBool("Flash", true);
                Instantiate(damageAnim, Vector2.up * 3, Quaternion.identity);
            }
        }
    }

    private int GetDamageFromPosition()
    {
        float xPos = Mathf.Abs(transform.position.x);

        int areaMultiplier = (xPos < 0.3f) ? 4 : (xPos < 1.39f) ? 3 : (xPos < 3f) ? 2 : 1;
        int randomMultiplier = Random.Range(0, 3);

        return areaMultiplier * ((randomMultiplier == 0) ? 10 : (randomMultiplier == 1) ? 14 : 18);
    }

    private IEnumerator DamageAnim()
    {
        damageAnim.SetActive(true);
        yield return new WaitForSeconds(0.06f);
        damageAnim.SetActive(false);
    }

    public void ToggleMovement(bool toggle)
    {
        moving = toggle;

        if (toggle)
        {
            animator.SetBool("Flash", false);
        }
    }
}
