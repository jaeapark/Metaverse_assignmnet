using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMapScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int totalScore = PlayerPrefs.GetInt("TotalMiniGameScore", 0);
        scoreText.text = $"누적 트레이닝 점수: {totalScore}";
    }
}
