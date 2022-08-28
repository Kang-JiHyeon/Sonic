using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public enum GameState
    {
        //Load,
        Ready,
        Start,
        Playing,
        GameOver,
        Ending
    }

    public GameState m_state = GameState.Ready;
    public static GameManager1 gameManager;

    public GameObject startUI;
    public GameObject playUI;
    public GameObject endUI;
    public GameObject gameoverUI;

    public Text playTime;
    public Text textScore;


    public void Awake()
    {
        gameManager = this;
    }

    void Update()
    {
        switch (m_state)
        {
            //case GameState.Load:
            //    LoadState();
            //    break;
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
            case GameState.Ending:
                EndingState();
                break;

        }
    }
    //float loadDelayTime = 5f;
    //private void LoadState()
    //{ 
    //    currentTime += Time.deltaTime;
    //    if (currentTime > loadDelayTime)
    //    {
    //        m_state = GameState.Ready;
    //        currentTime = 0;
    //        SceneManager.LoadScene("StartScene");
    //    }
    //}

    float currentTime = 0;
    float startDelayTime = 1;

    private void ReadyState()
    {

    }

    private void StartState()
    {
        currentTime += Time.deltaTime;
        if (currentTime > startDelayTime)
        {
            DontDestroyOnLoad(GameObject.Find("BGM"));
            SceneManager.LoadScene(2);// SelectScene
            m_state = GameState.Playing;
            currentTime = 0;
        }
    }

    private void PlayingState()
    {
    }

    float gameoverDelayTime = 5;
    private void GameOverState()
    {
        gameoverUI.SetActive(true);
        currentTime += Time.deltaTime;
        if (currentTime > gameoverDelayTime)
        {
            SceneManager.LoadScene("EndScene");
            currentTime = 0;
        }
    }

    private void EndingState()
    {
        textScore.text = PlayerPrefs.GetString("Score", "0");
        playTime.text = PlayerPrefs.GetString("PlayTime");
    }

    public void OnClickStart()
    {
        m_state = GameState.Start;
    }

    public void OnClickCharacterSelection()
    {
        //SceneManager.LoadScene("JH_MapScene1");
        Destroy(GameObject.Find("BGM"));
        SceneManager.LoadScene(3);

    }

    public void OnClickReStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
