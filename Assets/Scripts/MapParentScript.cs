using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapParentScript : MonoBehaviour
{
    private int moveSpeed = 60;

    public bool canMove = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndGroundLine"))
        {
            Debug.Log(collision.name);
            moveSpeed = 12;
        }
    }

    void Update()
    {
        if(canMove)
        {
            transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
        }
    }
}
