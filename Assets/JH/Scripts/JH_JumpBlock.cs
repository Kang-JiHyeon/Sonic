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
