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

    Transform player;
    public Transform[] landPos;
    int index = 0;
    // 플라잉?
    bool isFlying = false;
    private void Start()
    {
        originJumpPower = NK_PlayerMove.Instance.jumpPower;
        originMoveSpeed = NK_PlayerMove.Instance.speed;
        originGravity = NK_PlayerMove.Instance.gravity;

        player = NK_PlayerMove.Instance.gameObject.transform;
    }


    // 플라잉 블럭을 밟으면 RandPosition으로 이동하고 싶다.
    private void Update()
    {
        if (isFlying)
        {
            player.transform.position = Vector3.Lerp(player.position, landPos[index].position, Time.deltaTime);

            if(Vector3.Distance(player.position, landPos[index].position) < 0.1f)
            {
                //NK_PlayerMove.Instance.gravity = originGravity;
                player.position = landPos[index].position;
                NK_PlayerMove.Instance.enabled = false;
                isFlying = false;
                index = (index + 1) % landPos.Length;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = true;
            //NK_PlayerMove.Instance.speed = originMoveSpeed * flyingBlockSpeed;
            
            Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal = true;

            isFlying = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = false;
            NK_PlayerMove.Instance.enabled = false;
        }

    }
}
