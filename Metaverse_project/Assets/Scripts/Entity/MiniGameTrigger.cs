using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    public GameObject popupUI;
    public MiniGameInput miniGameInput;

    private void Start()
    {
        if (popupUI == null)
            popupUI = GameObject.Find("PopupUI");

        if (miniGameInput == null)
            miniGameInput = FindObjectOfType<MiniGameInput>();
        if (popupUI != null)
            popupUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (popupUI != null)
                popupUI.SetActive(true);
            else
                Debug.LogError("PopupUI연결x");

            if (miniGameInput != null)
                miniGameInput.canEnterMiniGame = true;
            else
                Debug.LogError("MiniGameInput연결x");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (popupUI != null)
                popupUI.SetActive(false);
            if (miniGameInput != null)
                miniGameInput.canEnterMiniGame = false;
        }
    }
}
