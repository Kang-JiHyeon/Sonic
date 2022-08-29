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

    public JH_CinemachineDirector cine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            JH_SoundManager.Instance.PlaySound("Ending");

            // �� ����, �÷��� �ð�, ���� ����
            PlayerPrefs.SetString("PlayTime", playTime.text);
            PlayerPrefs.SetString("Ring", ring.text);
            PlayerPrefs.SetString("SumScore", score.text);

            // �޸��� player ��Ȱ��ȭ
            other.gameObject.SetActive(false);

            // �ó׸ӽ� ����
            cine.camera.enabled = true;
            cine.isPlay = true;
            cine.pd.Play();
        }
    }
}
