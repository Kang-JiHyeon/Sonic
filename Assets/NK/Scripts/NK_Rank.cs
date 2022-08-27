using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NK_Rank : MonoBehaviour
{
    public Text textRank;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        textRank = GetComponent<Text>();
        score = Int32.Parse(PlayerPrefs.GetString("SumScore"));
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 1000000)
        {
            textRank.text = "S";
        }
        else if (score >= 100000)
        {
            textRank.text = "A";
        }
        else if(score >= 50000)
        {
            textRank.text = "B";
        }
        else if (score >= 10000)
        {
            textRank.text = "C";
        }
        else
        {
            textRank.text = "D";
        }

    }
}
