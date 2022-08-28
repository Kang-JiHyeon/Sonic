using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ EndingPoint�� �����ϸ� �����ð� �ڿ� ���� ��ȯ�ϰ� �ʹ�.

public class JH_EndingPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            JH_SoundManager.Instance.PlaySound("Ending");
            GameManager.gameManager.m_state = GameManager.GameState.GameOver;
        }
    }
}
