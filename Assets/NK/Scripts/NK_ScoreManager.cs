using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NK_ScoreManager : MonoBehaviour
{
    public Text textSumScore;
    public Text coins;
    public Text playtimes;

    public int sumScore;

    public static NK_ScoreManager scoreManager;

    private void Awake()
    {
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
    }
}
