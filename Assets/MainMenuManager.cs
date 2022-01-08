using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI StateText;
    private void Awake()
    {
        switch (GameManager.instance.gameState)
        {
            case GameState.Victory:
                StateText.text = "WIN";
                break;
            case GameState.Lose:
                StateText.text = "LOSE";
                break;
        }
    }

    public void PlayGame()
    {
        GameManager.instance.UpdateGameState(GameState.GameRun);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
