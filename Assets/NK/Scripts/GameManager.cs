using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Ready,
        Start,
        Playing,
        GameOver
    }

    public GameState m_state = GameState.Ready;
    public static GameManager gameManager;

    public GameObject startUI;
    public GameObject playUI;
    public GameObject endUI;
    public GameObject gameoverUI;

    public void Awake()
    {
        gameManager = this;
    }

    void Update()
    {
        switch (m_state)
        {
            case GameState.Ready:
                ReadyState();
                break;
            case GameState.Start:
                StartState();
                break;
            case GameState.Playing:
                PlayingState();
                break;
            case GameState.GameOver:
                GameOverState();
                break;
        }
    }

    float currentTime = 0;
    public float readyDelayTime = 2;
    public float startDelayTime = 2;
    private void ReadyState()
    {
        currentTime += Time.deltaTime;
        if (currentTime > readyDelayTime)
        {
            m_state = GameState.Start;
            currentTime = 0;
        }
    }

    private void StartState()
    {
        currentTime += Time.deltaTime;
        if (currentTime > startDelayTime)
        {
            SceneManager.LoadScene("JH_MapScene");
            m_state = GameState.Playing;
            currentTime = 0;
        }
    }

    private void PlayingState()
    {
        
    }

    private void GameOverState()
    {
        gameoverUI.SetActive(true);
    }

    public void OnClickStart()
    {
        m_state = GameState.Start;
    }

    public void OnClickReStart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
