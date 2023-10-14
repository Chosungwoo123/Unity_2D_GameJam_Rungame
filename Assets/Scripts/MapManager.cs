using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private int testMapIndex;

    [SerializeField] private bool testMap;

    [SerializeField] private GameObject[] mapPrefab;

    private int maxMapIndex;
    private int curMaxMapIndex = 4;
    private int multiplyIndex = 1;

    private bool canMapIndexUp = true;

    private static MapManager _instance;

    public static MapManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(MapManager)) as MapManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        maxMapIndex = mapPrefab.Length;
    }

    private void Update()
    {
        if(GameManager.Instance.curScore >= 1000 * multiplyIndex && canMapIndexUp)
        {
            if(curMaxMapIndex + 2 < maxMapIndex)
            {
                multiplyIndex++;
                curMaxMapIndex += 2;
            }
            else if(curMaxMapIndex + 2 >= maxMapIndex)
            {
                canMapIndexUp = false;
                curMaxMapIndex = maxMapIndex;
            }
        }
    }

    public void makeNewMap()
    {
        if(testMap)
        {
            Instantiate(mapPrefab[testMapIndex], transform.position, Quaternion.identity).transform.parent = transform;
        }
        else
        {
            Debug.Log(curMaxMapIndex);
            Instantiate(mapPrefab[Random.Range(0, curMaxMapIndex)], transform.position,Quaternion.identity).transform.parent = transform;
        }
    }

    public void StopObstacle()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Debug.Log("Stop");
            transform.GetChild(i).GetComponent<MapParentScript>().canMove = false;
        }
    }
}
