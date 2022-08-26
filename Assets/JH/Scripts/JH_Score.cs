using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ������ ������ ������Ű�� �ʹ�.
// ������ UI�� ǥ���ϰ� �ʹ�.
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
