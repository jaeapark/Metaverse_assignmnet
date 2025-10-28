using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText; 

    void Start()
    {
        if (gameOverText == null)
            Debug.LogError("GameOverText연결x");

        if (scoreText == null)
            Debug.LogError("ScoreText연결x");

        gameOverText.gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
