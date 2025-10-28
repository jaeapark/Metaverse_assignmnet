using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;
    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        int previousScore = PlayerPrefs.GetInt("TotalMiniGameScore", 0);

        PlayerPrefs.SetInt("TotalMiniGameScore", previousScore + currentScore);
        PlayerPrefs.Save();

        Debug.Log($"누적 점수: {previousScore + currentScore}");

        Invoke(nameof(ReturnToMainMap), 2f);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("플레이 중 점수: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }

    private void ReturnToMainMap()
    {
        SceneManager.LoadScene("MainMap");
    }
}
