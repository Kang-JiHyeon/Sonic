using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NK_ScoreManager : MonoBehaviour
{
    public Text textSumScore;

    public int sumScore;

    public static NK_ScoreManager scoreManager;

    private void Awake()
    {
        textSumScore = GetComponent<Text>();
        scoreManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sumScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textSumScore.text = sumScore.ToString("D8");
        if (GameManager.gameManager.m_state == GameManager.GameState.GameOver)
        {
            PlayerPrefs.SetString("SumScore", textSumScore.text);
        }
        if (GameManager.gameManager.m_state == GameManager.GameState.Ending)
        {
            textSumScore.text = PlayerPrefs.GetString("SumScore");
        }
    }
}
