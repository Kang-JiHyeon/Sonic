using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 EndingPoint에 도달하면 일정시간 뒤에 씬을 전환하고 싶다.

public class JH_EndingPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            if (!JH_SoundManager.Instance.audioSourceDic["Ending"])
                JH_SoundManager.Instance.PlaySound("Ending");

            GameManager.gameManager.m_state = GameManager.GameState.GameOver;

        }
    }
}
