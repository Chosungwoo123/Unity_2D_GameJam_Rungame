using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    static DataManager instance;

    public int maxScore;

    private string KeyString = "Best Score";

    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        maxScore = PlayerPrefs.GetInt(KeyString);
    }

    public void SetBestScore(int bestScore)
    {
        maxScore = bestScore;
    }

    public void SaveBestScore()
    {
        PlayerPrefs.SetInt(KeyString, maxScore);
    }

    public int GetBestScore()
    {
        if (maxScore > 0)
        {
            return maxScore;
        }
        else
        {
            return 0;
        }
    }
}
