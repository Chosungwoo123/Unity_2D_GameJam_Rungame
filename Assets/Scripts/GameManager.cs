using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject blackScreenObj;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject bestScoreImageStar;
    [SerializeField] private GameObject newScoreImage;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameOverScoreText;

    [SerializeField] private BackGround backGroundScript;

    private RectTransform gameOverUIRT;

    public int curScore = 0;

    //싱글톤
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

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

        gameOverUIRT = gameOverUI.GetComponent<RectTransform>();
    }

    private void Update()
    {
        UIUpdate();
    }

    private void UIUpdate()
    {
        scoreText.text = string.Format("{0:n0}", curScore);
        gameOverScoreText.text = "Score: " + string.Format("{0:n0}", curScore);
    }

    public void PlusScore(int score)
    {
        curScore += score;

        if(curScore > DataManager.Instance.GetBestScore())
        {
            DataManager.Instance.maxScore = curScore;
            DataManager.Instance.SaveBestScore();
            bestScoreImageStar.SetActive(true);
            newScoreImage.SetActive(true);
        }
    }

    public void LoadGameOverImage()
    {
        blackScreenObj.SetActive(true);
        gameOverUI.SetActive(true);
        gameOverUIRT.DOAnchorPosY(-30, 1).SetEase(Ease.OutBounce);
    }

    public void TimeStop()
    {
        MapManager.Instance.StopObstacle();

        backGroundScript.canScrolling = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToTitleScene()
    {
        SceneManager.LoadScene(0);
    }
}
