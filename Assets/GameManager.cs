using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState gameState;

    public static event Action<GameState> OnGameStateChanged;
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void UpdateGameState(GameState newState)
    {
        gameState = newState;
        switch (newState) {
            case GameState.MainMenu:
                HandleMainMenu();
                break;
            case GameState.GameRun:
                HandleGameRun();
                break;
            case GameState.Victory:
                HandleGameVictory();
                break;
            case GameState.Lose:
                HandleGamelose();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
    private void HandleGameRun()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }
    private void HandleGameVictory()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
    private void HandleGamelose()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
}

public enum GameState
{
    MainMenu,
    GameRun,
    Victory,
    Lose
}