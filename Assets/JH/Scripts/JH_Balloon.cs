using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어와 닿으면 없어지고 싶다.
public class JH_Balloon : MonoBehaviour
{
    public GameObject balloonEffectFactory;
    GameObject player;

    private void Start()
    {
        player = NK_PlayerMove.Instance.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            NK_Attack.Instance.enemys.Remove(gameObject);
            GameObject hitEffect = Instantiate(balloonEffectFactory);
            hitEffect.transform.position = gameObject.transform.position;
            Destroy(gameObject);
            NK_ScoreManager.scoreManager.sumScore += 1000;

            // 오디오 재생
            if (!JH_SoundManager.Instance.audioSourceDic["Balloon"].isPlaying)
            {
                JH_SoundManager.Instance.PlaySound("Balloon");
            }
        }
    }
}
