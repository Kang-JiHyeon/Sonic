using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ���� ����� ������ �÷��̾��� ���������� ���� �ְ� �ʹ�.
// �ʿ�Ӽ�: �÷��̾�, �÷��̾��� yVelocity
public class JH_JumpBlock : MonoBehaviour
{
    public float originJumpSpeed;
    float jumpBlockPower = 20f;

    private void Start()
    {
        originJumpSpeed = NK_PlayerMove.Instance.jumpSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            NK_PlayerMove.Instance.isJumpBlock = true;
            NK_PlayerMove.Instance.jumpSpeed = jumpBlockPower;
            //print(JH_PlayerMove.Instance.jumpSpeed); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        NK_PlayerMove.Instance.isJumpBlock = false;
        NK_PlayerMove.Instance.jumpSpeed = originJumpSpeed;
    }
}
