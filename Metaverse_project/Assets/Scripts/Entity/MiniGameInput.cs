using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameInput : MonoBehaviour
{
    public string miniGameSceneName = "MiniGameScene";
    [HideInInspector] public bool canEnterMiniGame = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canEnterMiniGame)
        {
            SceneManager.LoadScene(miniGameSceneName);
        }
    }
}
