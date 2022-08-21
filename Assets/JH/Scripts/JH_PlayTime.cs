using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ��� �ð��� ǥ���ϰ� �ʹ�.
public class JH_PlayTime : MonoBehaviour
{
    // �ʿ�Ӽ�: �ؽ�Ʈ, ����ð�
    Text playTime;
    float min;
    string sec, msec;

    // Start is called before the first frame update
    void Start()
    {
        playTime = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // minute
        min = (int)Time.time / 60 % 60;
        // second
        sec = string.Format("{0:00}", (int)Time.time % 60);
        // ms
        msec = string.Format("{0:.00}", Time.time % 1).Replace(".", "");

        playTime.text = $"{min}:{sec}:{msec}";

        if (GameManager.gameManager.m_state == GameManager.GameState.GameOver)
        {
            PlayerPrefs.SetString("PlayTime", playTime.text);
        }
    }
}
