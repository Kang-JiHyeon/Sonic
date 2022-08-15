using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ���� ����� ������ �÷��̾��� ���������� ���� �ְ� �ʹ�.
// �ʿ�Ӽ�: �÷��̾�, �÷��̾��� yVelocity
public class JH_FlyingBlock : MonoBehaviour
{
    // ���� ��
    public float originJumpPower;
    public float flyingJumpPower = 3f;

    // ������ �ӵ�
    public float originMoveSpeed;
    public float flyingBlockSpeed = 2;

    // �߷�
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
            NK_PlayerMove.Instance.speed = originMoveSpeed * flyingBlockSpeed;
            NK_PlayerMove.Instance.gravity = originGravity * flyingGravity;
            
            Camera.main.gameObject.GetComponent<JH_Camera>().isVertical = false;
            Camera.main.gameObject.GetComponent<JH_Camera>().isHorizontal = true;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = false;
            //NK_PlayerMove.Instance.jumpPower = originJumpPower;
            //NK_PlayerMove.Instance.speed = originMoveSpeed;
            //NK_PlayerMove.Instance.gravity = originGravity;

        }

    }
}
