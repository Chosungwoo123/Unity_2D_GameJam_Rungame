using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [Header("���� ������ ������ �ݶ��̴��� ������ٵ� �߰����ּ���.")]

    [SerializeField] private GameObject parentObject;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EndLine"))
        {
            Destroy(gameObject);
        }
        if(collision.CompareTag("StartLine"))
        {
            MapManager.Instance.makeNewMap();
        }
    }
}
