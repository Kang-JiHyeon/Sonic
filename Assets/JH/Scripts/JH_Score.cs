using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 링을 먹으면 점수를 증가시키고 싶다.
// 점수를 UI에 표시하고 싶다.
public class JH_Score : MonoBehaviour
{
    public Text textScore;
    int score = 0;

    public int SCORE
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            textScore.text = score.ToString("D4");
        }
    }

    public static JH_Score Instance;

    void Awake()
    {
            Instance = this;
    }
    private void Start()
    { 
        textScore = GameObject.Find("Text_ScoreValue").GetComponent<Text>();
    }

    private void Update()
    {
        if (GameManager.gameManager.m_state == GameManager.GameState.GameOver)
        {
            PlayerPrefs.SetString("Score", textScore.text);
        }
    }
}
