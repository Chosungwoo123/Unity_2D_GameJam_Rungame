using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("Die");
        GameManager.Instance.TimeStop();
        Destroy(rigid);
    }
}
