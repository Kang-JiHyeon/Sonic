using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 점프 블록을 밟으면 플레이어의 윗방향으로 힘을 주고 싶다.
// 필요속성: 플레이어, 플레이어의 yVelocity
public class JH_JumpBlock : MonoBehaviour
{
    public float originJumpSpeed;
    float jumpBlockPower = 20f;

    private void Start()
    {
        originJumpSpeed = JH_PlayerMove.Instance.jumpSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            JH_PlayerMove.Instance.isJumpBlock = true;
            JH_PlayerMove.Instance.jumpSpeed = jumpBlockPower;
            //print(JH_PlayerMove.Instance.jumpSpeed); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        JH_PlayerMove.Instance.isJumpBlock = false;
        JH_PlayerMove.Instance.jumpSpeed = originJumpSpeed;
    }
}
