using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 점프 블록을 밟으면 플레이어의 윗방향으로 힘을 주고 싶다.
// 필요속성: 플레이어, 플레이어의 yVelocity
public class JH_JumpBlock : MonoBehaviour
{

    float originJumpPower = 15f;
    public float jumpBlockPower = 20f;

    private void Start()
    {
        //originJumpPower = NK_PlayerMove.Instance.jumpPower;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = true;
            NK_PlayerMove.Instance.jumpPower = jumpBlockPower;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        NK_PlayerMove.Instance.isJumpBlock = false;
        NK_PlayerMove.Instance.jumpPower = originJumpPower;
    }
}
