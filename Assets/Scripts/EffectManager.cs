using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private GameObject itemEatEffectPrefab;
    [SerializeField] private GameObject magnetEatEffectPrefab;

    static EffectManager instance;

    public static EffectManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!instance)
            {
                instance = FindObjectOfType(typeof(EffectManager)) as EffectManager;

                if (instance == null)
                    Debug.Log("no Singleton obj");
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void MakeItemEatEffect(Transform spawnPoint)
    {
        Debug.Log("Effect");
        GameObject EatEffect = Instantiate(itemEatEffectPrefab);
        EatEffect.transform.position = spawnPoint.position;
    }

    public void MakeMagnetEatEffect(Transform spawnPoint)
    {
        Debug.Log("Effect");
        GameObject EatEffect = Instantiate(magnetEatEffectPrefab);
        EatEffect.transform.position = spawnPoint.position;
    }
}
