using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBar : MonoBehaviour
{
    public float speed = 8f;

    public GameObject damageAnim;

    private int direction = 1;
    private bool moving = true;

    private void Update()
    {
        if (moving)
        {
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

            if (transform.position.x > 3.825f)
            {
                direction = -1;
            }
            else if (transform.position.x < -3.825f)
            {
                direction = 1;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ToggleMovement(false);
                GameManager.instance.playerDamage.damage = GetDamageFromPosition();
                Instantiate(damageAnim, Vector2.up * 3, Quaternion.identity);
            }
        }
    }

    private int GetDamageFromPosition()
    {
        int calculatedDamage;
        calculatedDamage = 50 - Mathf.CeilToInt(Mathf.Abs(transform.position.x) * 10.45f);
        return calculatedDamage;
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
    }
}
