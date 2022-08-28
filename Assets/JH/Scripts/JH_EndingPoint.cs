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

    public JH_CinemachineDirector cine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            JH_SoundManager.Instance.PlaySound("Ending");

            // 링 개수, 플레이 시간, 점수 저장
            PlayerPrefs.SetString("PlayTime", playTime.text);
            PlayerPrefs.SetString("Ring", ring.text);
            PlayerPrefs.SetString("SumScore", score.text);

            // 달리는 player 비활성화
            other.gameObject.SetActive(false);

            // 시네머신 실행
            cine.camera.enabled = true;
            cine.isPlay = true;
            cine.pd.Play();
        }
    }
}
