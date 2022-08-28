using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 플레이어가 EndingPoint에 도달하면 일정시간 뒤에 씬을 전환하고 싶다.

public class JH_EndingPoint : MonoBehaviour
{
    public Text playTime;
    public Text ring;
    public Text score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            JH_SoundManager.Instance.PlaySound("Ending");
            //GameManager.gameManager.m_state = GameManager.GameState.GameOver;

            // 링 개수, 플레이 시간, 점수 저장
            PlayerPrefs.SetString("PlayTime", playTime.text);
            PlayerPrefs.SetString("Ring", ring.text);
            PlayerPrefs.SetString("SumScore", score.text);

            GameManager.gameManager.m_state = GameManager.GameState.GameOver;
        }
    }
}
