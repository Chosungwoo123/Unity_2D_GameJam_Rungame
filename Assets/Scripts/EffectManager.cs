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
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
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
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
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
