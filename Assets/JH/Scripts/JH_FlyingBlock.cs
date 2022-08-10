using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 점프 블록을 밟으면 플레이어의 윗방향으로 힘을 주고 싶다.
// 필요속성: 플레이어, 플레이어의 yVelocity
public class JH_FlyingBlock : MonoBehaviour
{
    // 점프 힘
    public float originJumpPower;
    public float flyingJumpPower = 3f;

    // 움직임 속도
    public float originMoveSpeed;
    public float flyingBlockSpeed = 2;

    // 중력
    public float originGravity;
    public float flyingGravity = 0.1f;

    private void Start()
    {
        originJumpPower = NK_PlayerMove.Instance.jumpPower;
        originMoveSpeed = NK_PlayerMove.Instance.speed;
        originGravity = NK_PlayerMove.Instance.gravity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = true;
            //NK_PlayerMove.Instance.jumpPower = originJumpPower * flyingJumpPower;
            NK_PlayerMove.Instance.speed = originMoveSpeed * flyingBlockSpeed;
            NK_PlayerMove.Instance.gravity = originGravity * flyingGravity;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        NK_PlayerMove.Instance.isJumpBlock = false;
        //NK_PlayerMove.Instance.jumpPower = originJumpPower;
        //NK_PlayerMove.Instance.speed = originMoveSpeed;
        //NK_PlayerMove.Instance.gravity = originGravity;
    }
}
