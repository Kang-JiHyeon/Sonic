using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NK_ScoreManager : MonoBehaviour
{
    public Text textSumScore;

    int _sumScore = 0;
    int _topScore = 0;
    public int sumScore
    {
        get { return _sumScore; }
        set { _sumScore = value;
            textSumScore.text = _sumScore.ToString("D8");
            if (_sumScore > _topScore)
            {
                _topScore = _sumScore;
                PlayerPrefs.SetInt("TopScore", _topScore);
            }
        }
    }

    public static NK_ScoreManager scoreManager;

    private void Awake()
    {
        textSumScore = GetComponent<Text>();
        scoreManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _topScore = PlayerPrefs.GetInt("TopScore", 0);
        sumScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textSumScore.text = sumScore.ToString("D8");

        if (GameManager.gameManager.m_state == GameManager.GameState.Ending)
        {
            textSumScore.text = PlayerPrefs.GetString("SumScore");
        }
    }
}
