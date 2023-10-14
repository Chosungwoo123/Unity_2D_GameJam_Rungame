using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [Header("다음 패턴이 생성될 콜라이더랑 리지드바디를 추가해주세요.")]

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
