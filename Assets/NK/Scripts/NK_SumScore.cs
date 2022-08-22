using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NK_SumScore : MonoBehaviour
{
    public Text textSumScore;

    int sumScore;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        string playtime = PlayerPrefs.GetString("PlayTime");

        sumScore = Int32.Parse(PlayerPrefs.GetString("Score")) * 30 + Int32.Parse(playtime[0].ToString()) * 1000000 + Int32.Parse(playtime[2].ToString()) * 100000 +
            Int32.Parse(playtime[3].ToString()) * 10000 + Int32.Parse(playtime[5].ToString()) * 1000 + Int32.Parse(playtime[6].ToString()) * 100;
    }

    // Update is called once per frame
    void Update()
    {
/*        if (score == sumScore)
        {
            return;
        }

        score += 1;*/

        textSumScore.text = sumScore.ToString();
    }
}
