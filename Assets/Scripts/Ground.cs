using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(-12, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("EndLine"))
        {
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("StartLine"))
        {
            Debug.Log("aa");
            MapManager.Instance.makeNewMap();
        }
    }
}
