using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;
    [SerializeField] private RectTransform explanationObjRT;

    public int bestScore;

    private void Start()
    {
        bestScore = DataManager.Instance.GetBestScore();

        bestScoreText.text = "Best: " + string.Format("{0:n0}", bestScore);
    }

    public void OpenExplanation()
    {
        explanationObjRT.DOAnchorPosY(0, 1).SetEase(Ease.OutQuint);
    }

    public void CloseExplanation()
    {
        explanationObjRT.DOAnchorPosY(-1200, 1).SetEase(Ease.OutQuint);
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        DataManager.Instance.SaveBestScore();
        Application.Quit();
    }
}
