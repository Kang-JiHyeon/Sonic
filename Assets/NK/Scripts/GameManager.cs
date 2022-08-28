using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Load,
        Ready,
        Start,
        Playing,
        GameOver,
        Ending
    }
    public static GameManager gameManager;

    public GameObject startUI;
    public GameObject playUI;
    public GameObject endUI;
    public GameObject gameoverUI;
    public GameObject loadingUI;

    public Text playTime;
    public Text textScore;

    public GameState m_state = GameState.Ready;

    public void Awake()
    {
        gameManager = this;
    }

    void LateUpdate()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                LoadState();
                break;
            case 1:
                StartState();
                break;
            case 2:
                // SelectScene
                break;
            case 3:
                PlayingState();
                break;
        }

        switch (m_state)
        {
            case GameState.GameOver:
                GameOverState();
                break;
            case GameState.Ending:
                EndingState();
                break;
        }
    }
    float currentTime = 0f;
    float loadDelayTime = 5f;
    private void LoadState()
    {
        currentTime += Time.deltaTime;
        if (currentTime > loadDelayTime)
        {
            currentTime = 0;
            SceneManager.LoadScene("StartScene");
        }
    }

    float startDelayTime = 1f;
    bool isStart = false;
    private void StartState()
    {
        if (!isStart)
            return;

        currentTime += Time.deltaTime;
        if (currentTime > startDelayTime)
        {
            DontDestroyOnLoad(GameObject.Find("BGM"));
            SceneManager.LoadScene(2);  // SelectScene
            currentTime = 0;
        }
    }

    private void PlayingState()
    {

    }

    float gameoverDelayTime = 2f;
    private void GameOverState()
    {
        //gameoverUI.SetActive(true);
        //currentTime += Time.deltaTime;
        //if (currentTime > gameoverDelayTime)
        //{
        //    m_state = GameState.Ending;
        //    currentTime = 0;
        //    SceneManager.LoadScene("EndScene");
        //}
        //m_state = GameState.Ending;

        m_state = GameState.Ending;
        SceneManager.LoadScene("EndScene");
    }

    private void EndingState()
    {
        textScore.text = PlayerPrefs.GetString("Ring");
        playTime.text = PlayerPrefs.GetString("PlayTime");
    }

    public void OnClickStart()
    {
        isStart = true;
    }

    public void OnClickCharacterSelection()
    {
        loadingUI.SetActive(true);
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
