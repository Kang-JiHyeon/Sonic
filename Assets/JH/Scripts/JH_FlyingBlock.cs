using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ���� ����� ������ �÷��̾��� ���������� ���� �ְ� �ʹ�.
// �ʿ�Ӽ�: �÷��̾�, �÷��̾��� yVelocity
public class JH_FlyingBlock : MonoBehaviour
{
    public float originJumpSpeed;
    public float jumpBlockPower = 30f;

    public float originMoveSpeed;
    public float flyingBlockSpeed = 20f;

    private void Start()
    {
        originJumpSpeed = NK_PlayerMove.Instance.jumpSpeed;
        originMoveSpeed = NK_PlayerMove.Instance.speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = true;
            NK_PlayerMove.Instance.jumpSpeed = jumpBlockPower;
            NK_PlayerMove.Instance.speed = flyingBlockSpeed;

            //print(JH_PlayerMove.Instance.jumpSpeed); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        NK_PlayerMove.Instance.isJumpBlock = false;
        NK_PlayerMove.Instance.jumpSpeed = originJumpSpeed;
        NK_PlayerMove.Instance.jumpSpeed = flyingBlockSpeed;
    }
}
