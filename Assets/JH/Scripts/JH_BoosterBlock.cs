using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 부스터 블럭을 지나가면 부스터 상태로 변경하고 싶다.
public class JH_BoosterBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 감지되면
        if (other.gameObject.name.Contains("Player"))
        {
            // 플레이어의 부스터 상태를 true로 변경하고 싶다.
            other.GetComponent<NK_Booster>().isBooster = true;
        }
    }
}
