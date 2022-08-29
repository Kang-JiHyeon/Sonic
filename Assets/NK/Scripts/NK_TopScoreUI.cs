using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_TopScoreUI : MonoBehaviour
{
    public GameObject topScore;
    public GameObject topPlayTime;
    public GameObject topRing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ts = PlayerPrefs.GetInt("TopScore");
        var ss = Int32.Parse(PlayerPrefs.GetString("SumScore"));
        if (PlayerPrefs.GetInt("TopScore") <= Int32.Parse(PlayerPrefs.GetString("SumScore")))
        {
            topScore.SetActive(true);
        }

        /*if (PlayerPrefs.GetString("PlayTime") <= PlayerPrefs.GetString("TopPlayTime"))
        {

        }*/

        if (PlayerPrefs.GetInt("TopRing") <= Int32.Parse(PlayerPrefs.GetString("Ring")))
        {
            topRing.SetActive(true);
        }
    }
}
