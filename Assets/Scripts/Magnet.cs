using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float radius;

    [SerializeField] private LayerMask whatIsMagnetObj;

    private void Update()
    {
        MagnetCheck();
    }

    private void MagnetCheck()
    {
        Collider2D[] magnetObjdects = Physics2D.OverlapCircleAll(transform.position, radius, whatIsMagnetObj);

        foreach (Collider2D collider in magnetObjdects)
        {
            Vector2 dir = this.transform.position - collider.transform.position;

            collider.transform.Translate(dir.normalized * 15 * Time.deltaTime, Space.World);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
