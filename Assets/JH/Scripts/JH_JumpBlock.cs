using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ���� ����� ������ �÷��̾��� ���������� ���� �ְ� �ʹ�.
// �ʿ�Ӽ�: �÷��̾�, �÷��̾��� yVelocity
public class JH_JumpBlock : MonoBehaviour
{

    public float originJumpPower;
    public float jumpBlockPower = 2f;

    private void Start()
    {
        originJumpPower = NK_PlayerMove.Instance.jumpPower;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = true;
            NK_PlayerMove.Instance.jumpPower = originJumpPower * jumpBlockPower;

            // ���� ���
            JH_SoundManager.Instance.PlaySound("JumpBlock");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        NK_PlayerMove.Instance.isJumpBlock = false;
        NK_PlayerMove.Instance.jumpPower = originJumpPower;
    }
}
