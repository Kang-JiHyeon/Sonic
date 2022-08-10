using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ���� ����� ������ �÷��̾��� ���������� ���� �ְ� �ʹ�.
// �ʿ�Ӽ�: �÷��̾�, �÷��̾��� yVelocity
public class JH_FlyingBlock : MonoBehaviour
{
    public float originJumpPower;
    public float jumpBlockPower = 30f;

    public float originMoveSpeed;
    public float flyingBlockSpeed = 20f;

    private void Start()
    {
        originJumpPower = NK_PlayerMove.Instance.jumpPower;
        originMoveSpeed = NK_PlayerMove.Instance.speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = true;
            NK_PlayerMove.Instance.jumpPower = jumpBlockPower;
            NK_PlayerMove.Instance.speed = flyingBlockSpeed;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        NK_PlayerMove.Instance.isJumpBlock = false;
        NK_PlayerMove.Instance.jumpPower = originJumpPower;
        NK_PlayerMove.Instance.speed = originMoveSpeed;
    }
}
