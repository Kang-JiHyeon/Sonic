using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �÷��̾ EndingPoint�� �����ϸ� �����ð� �ڿ� ���� ��ȯ�ϰ� �ʹ�.

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

            // �� ����, �÷��� �ð�, ���� ����
            PlayerPrefs.SetString("PlayTime", playTime.text);
            PlayerPrefs.SetString("Ring", ring.text);
            PlayerPrefs.SetString("SumScore", score.text);

            GameManager.gameManager.m_state = GameManager.GameState.GameOver;
        }
    }
}
