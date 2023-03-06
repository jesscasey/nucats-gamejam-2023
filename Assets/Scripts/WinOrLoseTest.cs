using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLoseTest : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.endMinigame += EndMinigame;
        GameManager.beginMinigame += BeginMinigame;
        GameManager.winMinigame += WinMinigame;
        GameManager.loseMinigame += LoseMinigame;
    }
    private void OnDisable()
    {
        GameManager.endMinigame -= EndMinigame;
        GameManager.beginMinigame -= BeginMinigame;
        GameManager.winMinigame -= WinMinigame;
        GameManager.loseMinigame -= LoseMinigame;
    }
    void EndMinigame(bool isWon)
    {
        string winOrLose = isWon ? "Win" : "Loss";
        Debug.Log("Minigame Ended in a " + winOrLose);
    }
    void BeginMinigame()
    {
        Debug.Log("Minigame Start");
    }
    void WinMinigame()
    {
        Debug.Log("WIN");
    }
    void LoseMinigame()
    {
        Debug.Log("LOSE");
    }

}
