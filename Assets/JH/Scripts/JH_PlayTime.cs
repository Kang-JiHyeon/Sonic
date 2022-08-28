using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

// 경과 시간을 표시하고 싶다.
public class JH_PlayTime : MonoBehaviour
{
    public static JH_PlayTime Instance;
    
    // 필요속성: 텍스트, 경과시간
   
    public Text playTime;
    string min, sec, msec;
    float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;

        playTime = GetComponent<Text>();
        min = "00";
        sec = "00";
        msec = "00";

        playTime.text = $"{min}:{sec}:{msec}";

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // minute
        min = string.Format("{0:00}", (int)(currentTime) / 60 % 60);
        // second
        sec = string.Format("{0:00}", (int)currentTime % 60);
        // ms
        msec = string.Format("{0:.00}", currentTime % 1).Replace(".", "");

        playTime.text = $"{min}:{sec}:{msec}";

    }
}
